using CopyPara.Application.Machine;
using CopyPara.Application.Utilization;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Occasions;
using CopyPara.Domain.Utilizations;

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
        public async Task<TimeSlot> TimeSlot(DateTime start, DateTime end, int length,MachineType machineType, CancellationToken cancellationToken)
        {
            var slot = new TimeSlot();
            var days = EachDay(start, end);
            var machines = await _machineRepository.GetMachinesAsync(machineType,cancellationToken);
            /*TO-DO: Filter machine by opened slots*/
            ulong machineId = machines[0].Id;
            int uti = await _utilizationRepository.GetUtilizationSum(start,end,machineId,cancellationToken);
            foreach (var machine in machines)
            {
                int copUti = await _utilizationRepository.GetUtilizationSum(start, end, machine.Id, cancellationToken);
                if (copUti < uti)
                {
                    machineId = machine.Id;
                    uti = copUti;
                }
            }

            SlotType slotType = SlotTypeExtensions.TimeToSlot(length);

            var utilizationFirstDay = await _utilizationRepository.FindUtilizationAsync(start, machineId, cancellationToken);
            var openSlotsFirstDay = utilizationFirstDay.Slots.Where(x => x.Type == slotType && x.TimeSlots.Count() < slotType.SlotToQuantity());

            foreach (var openSlotFirstDay in openSlotsFirstDay)
            {
                var isOpened = true;
                foreach(var day in days)
                {
                    var utilization = await _utilizationRepository.FindUtilizationAsync(day, machineId, cancellationToken);
                    isOpened &= utilization.Slots.Where(x => x.Start == openSlotFirstDay.Start)?.All(x => x.Type == openSlotFirstDay.Type) ?? true;
                }

                if(isOpened)
                {
                    slot.StartTime = openSlotFirstDay.Start + openSlotFirstDay.TimeSlots.Count() * slotType.SlotToQuantity();
                    slot.EndTime = slot.StartTime + slotType.SlotToQuantity();
                    return slot;
                }
            }

            var emptySlotsFirstDay = utilizationFirstDay.Slots.Where(x => !x.TimeSlots?.Any() ?? true);

            foreach (var openSlotFirstDay in emptySlotsFirstDay)
            {
                var isOpened = true;
                foreach (var day in days)
                {
                    var utilization = await _utilizationRepository.FindUtilizationAsync(day, machineId, cancellationToken);
                    isOpened &= utilization.Slots.Where(x => x.Start == openSlotFirstDay.Start)?.All(x => !x.TimeSlots?.Any() ?? true) ?? true;
                }

                if (isOpened)
                {
                    slot.StartTime = openSlotFirstDay.Start + openSlotFirstDay.TimeSlots.Count() * slotType.SlotToQuantity();
                    slot.EndTime = slot.StartTime + slotType.SlotToQuantity();
                    return slot;
                }
            }

            return slot;
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


    }
}
