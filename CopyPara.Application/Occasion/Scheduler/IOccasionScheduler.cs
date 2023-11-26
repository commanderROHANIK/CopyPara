using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Occasion.Scheduler
{
    public interface IOccasionScheduler
    {
        Task<MachineType> MachineType(Domain.Treatments.Treatment request, CancellationToken cancellationToken);
        Task<TimeSlot> TimeSlot(DateTime start, DateTime end, int length, MachineType machineType, CancellationToken cancellationToken);
        Task<ulong> CalculateMachineId(DateTime start, DateTime end, MachineType machineType, CancellationToken cancellationToken);
    }
}
