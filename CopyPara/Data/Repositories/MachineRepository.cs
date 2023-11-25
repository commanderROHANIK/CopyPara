using CopyPara.Application.Machine;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using Microsoft.EntityFrameworkCore;

namespace CopyPara.Data.Repositories;

public sealed class MachineRepository : IMachineRepository
{
    private readonly ApplicationDbContext _context;

    public MachineRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ValueTask<Machine?> GetMachineAsync(ulong machineId, CancellationToken cancellationToken = default)
    {
        return _context.Machines.FindAsync(machineId, cancellationToken);
    }

    public IAsyncEnumerable<Machine> GetAllMachines(CancellationToken cancellationToken = default)
    {
        return _context.Machines.AsAsyncEnumerable();
    }

    public Task<Machine[]> GetMachinesAsync(MachineType type,CancellationToken cancellationToken = default)
    {
        return _context.Machines.Where(x => x.MachineType == type).ToArrayAsync(cancellationToken); ;
    }

}
