using System.Security.Claims;
using CopyPara.Application;
using CopyPara.Data;
using CopyPara.Domain.Doctors;
using Microsoft.EntityFrameworkCore;

namespace CopyPara;

public sealed class AuthenticatedDoctor : IAuthDoctor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _context;

    public AuthenticatedDoctor(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Doctor?> GetAuthenticatedDoctorAsync(CancellationToken cancellationToken = default)
    {
        var id = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(id))
        {
            return null;
        }

        var doc = await _context.Doctors.FirstOrDefaultAsync(x => x.ApplicationUserId == id, cancellationToken);

        return doc;
    }
}
