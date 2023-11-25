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
        // Task<TimeSlot> TimeSlot(DateTime start, DateTime end, int length, MachineType machineType, CancellationToken cancellationToken);
    }
}
