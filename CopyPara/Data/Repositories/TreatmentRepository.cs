using CopyPara.Application;
using CopyPara.Application.Treatment;
using CopyPara.Domain.Cancers;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class TreatmentRepository : ITreatmentRepository
{
    private readonly ApplicationDbContext _context;

    public TreatmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Treatment treatment, CancellationToken cancellationToken = default)
    {
        await _context.Treatments.AddAsync(treatment, cancellationToken);
    }

    public Task<Treatment[]> GetAllTreatment(CancellationToken cancellationToken = default)
    {
        return _context.Treatments.Include(x => x.Patient).Include(x => x.Cancer).ToArrayAsync(cancellationToken);
    }

    public ValueTask<Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default)
    {
        return _context.Cancers.FindAsync(cancerId, cancellationToken);
    }

    public async Task<IEnumerable<DocTreatments>> GetDoctorsTreatments(ulong doctorId, CancellationToken cancellationToken = default)
    {
        var treatments = await _context.Treatments
            .AsNoTracking()
            .Include(x => x.Patient)
            .Where(x => x.DoctorId == doctorId)
            .OrderBy(x => x.StartDate)
            .Select(x => new DocTreatments
            {
                Id = x.Id,
                PatientName = x.Patient.Name,
                Occasions = x.Occasions.Count()
            })
            .ToArrayAsync(cancellationToken);

        return treatments;
    }

    public ValueTask<Treatment?> GetTreatmentAsync(ulong treatmentId, CancellationToken cancellationToken = default)
    {
        return _context.Treatments.FindAsync(treatmentId, cancellationToken);
    }

    Task<Application.Treatment.GetCancer.Cancer[]> ITreatmentRepository.GetCancersForSelectAsync(CancellationToken cancellationToken)
    {
         return _context.Cancers
            .Select(x => new Application.Treatment.GetCancer.Cancer(x.Id, x.CancerType.ToFastString(), x.GetFractions(), x.AvgTimeMins))
            .ToArrayAsync(cancellationToken);
    }
}
