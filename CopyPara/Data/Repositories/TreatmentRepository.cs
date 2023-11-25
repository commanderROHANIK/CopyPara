using CopyPara.Application.Patient;
using CopyPara.Application.Treatment;
using CopyPara.Domain.Cancers;
using CopyPara.Domain.Patients;
using CopyPara.Domain.Treatments;
using System.Runtime.InteropServices;

namespace CopyPara.Data.Repositories;

public sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly ApplicationDbContext _context;

    public TreatmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Treatment treatment, CancellationToken cancellationToken = default)
    {
        await _context.Treatments.AddAsync(treatment, cancellationToken);
    }

    public ValueTask<Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default)
    {
        return _context.Cancers.FindAsync(cancerId, cancellationToken);
    }
}
