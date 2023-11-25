using CopyPara.Application.Machine;
using CopyPara.Application.Occasion;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class OccasionRepository : IOccasionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly TimeProvider _timeProvider;

    public OccasionRepository(ApplicationDbContext context, TimeProvider timeProvider)
    {
        _context = context;
        _timeProvider = timeProvider;
    }

    public async Task AddAsync(Occasion occasion, CancellationToken cancellationToken = default)
    {
        await _context.Occasions.AddAsync(occasion, cancellationToken);
    }

    public ValueTask<Occasion?> GetOccasionAsync(ulong occasionId, CancellationToken cancellationToken = default)
    {
        return _context.Occasions.FindAsync(occasionId, cancellationToken);
    }

    public Task<Occasion[]> GetOccasionsByDayPerMachine(DateTime date, ulong machineId, CancellationToken cancellationToken = default)
    {
        return _context.Occasions.Where(x => x.MachineId == machineId && x.Date == date).ToArrayAsync(cancellationToken);
    }

    public Task<Occasion[]> GetOccasionsForTreatment(ulong treatmentId, CancellationToken cancellationToken = default)
    {
        return _context.Occasions.Where(x => x.TreatmentId == treatmentId).ToArrayAsync(cancellationToken);
    }

    public IAsyncEnumerable<Occasion> GetAllOccasions(CancellationToken cancellationToken = default)
    {
        return _context.Occasions.AsAsyncEnumerable();
    }

    public async Task DeleteOccasion(ulong doctorId, ulong treatmentId, CancellationToken cancellationToken = default)
    {
        var time = _timeProvider.GetUtcNow();

        var removables = await _context.Occasions
            // .AsNoTracking()
            // .Include(x => x.Treatment)
            .Where(x => x.TreatmentId == treatmentId)
            // .Where(x => x.Treatment.DoctorId == doctorId)
            .Where(x => (DateTime)(object)x.Date > time.Date)
            .ExecuteDeleteAsync(cancellationToken);

        // foreach (var removable in removables)
        // {
        //     _context.Occasions.Remove(removable);
        // }
    }
}
