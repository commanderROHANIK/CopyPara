using CopyPara.Application.Machine;
using CopyPara.Application.Occasion;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class OccasionRepository : IOccasionRepository
{
    private readonly ApplicationDbContext _context;

    public OccasionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Occasion occasion, CancellationToken cancellationToken = default)
    {
        await _context.Occasions.AddAsync(occasion, cancellationToken);
    }

    public ValueTask<Occasion?> GetOccasionAsync(ulong occasionId, CancellationToken cancellationToken = default)
    {
        return _context.Occasions.FindAsync(occasionId, cancellationToken);
    }

    public Task<Occasion[]> GetOccasionsForTreatment(ulong treatmentId, CancellationToken cancellationToken = default)
    {
        return _context.Occasions.Where(x => x.TreatmentId == treatmentId).ToArrayAsync(cancellationToken);
    }
}
