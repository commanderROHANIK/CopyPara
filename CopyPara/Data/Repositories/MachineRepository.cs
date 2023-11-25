using CopyPara.Application.Machine;
using CopyPara.Domain.Machines;

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

}
