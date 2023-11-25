using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Machine
{
    public interface IMachineRepository
    {
        ValueTask<Domain.Machines.Machine?> GetMachineAsync(ulong machineId, CancellationToken cancellationToken = default);
    }
}
