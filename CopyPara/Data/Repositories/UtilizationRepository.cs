using CopyPara.Application.Utilization;
using CopyPara.Domain.Utilizations;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class UtilizationRepository : IUtilizationRepository
{
    private readonly ApplicationDbContext _context;

    public UtilizationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Utilization uti, CancellationToken cancellationToken = default)
    {
        await _context.Utilization.AddAsync(uti, cancellationToken);
    }

    public async Task<Utilization> FindUtilizationAsync(DateTime date, ulong machineId, CancellationToken cancellationToken = default)
    {
        var uti = await _context.Utilization.FirstOrDefaultAsync(x => x.Date == date && x.MachineId == machineId, cancellationToken);
        return uti;
    }

    public void Update(Utilization uti)
    {
        _context.Utilization.Update(uti);
    }

    public async Task<int> GetUtilizationSum(DateTime start, DateTime end, ulong machineId, CancellationToken cancellationToken = default)
    {
        var uti = await _context.Utilization.Where(x => x.MachineId == machineId && x.Date >= start && x.Date <= end).SumAsync(x => x.CurrentUtilization);
        return uti;
    }

    public async Task<List<(ulong,int)>> GetUtilization(DateTime start, DateTime end, CancellationToken cancellationToken = default)
    {
        IQueryable<IGrouping<ulong, Utilization>> utis = _context.Utilization.Where(x => x.Date >= start && x.Date <= end).GroupBy(x => x.MachineId);

        List<(ulong,int)> result = [];

        foreach(var uti in utis)
        {
            var utilization = uti.Sum(x => x.CurrentUtilization);
            result.Add(new (uti.Key, utilization));
        }    
        return result;
    }
}
