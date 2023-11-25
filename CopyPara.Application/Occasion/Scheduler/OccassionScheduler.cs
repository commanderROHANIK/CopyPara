using CopyPara.Application.Machine;
using CopyPara.Application.Utilization;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;

namespace CopyPara.Application.Occasion.Scheduler
{
    public class OccassionScheduler : IOccasionScheduler 
    { 
        private readonly IUtilizationRepository _utilizationRepository;
        private readonly IMachineRepository _machineRepository;

        public OccassionScheduler(IUtilizationRepository utilizationRepository,
            IMachineRepository machineRepository)
        {
            _utilizationRepository = utilizationRepository;
            _machineRepository = machineRepository;
        }
        public TimeSlot GetTimeSlot(DateTime start,int length,MachineType machineType)
        {
            return new TimeSlot();
        }
    }
}
