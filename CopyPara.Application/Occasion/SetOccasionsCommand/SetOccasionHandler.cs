using CopyPara.Application.Machine;
using CopyPara.Application.Occasion;
using CopyPara.Application.Occasion.Scheduler;
using CopyPara.Application.Occasion.SetOccasionsCommand;
using CopyPara.Application.Treatment;
using CopyPara.Application.Utilization;
using CopyPara.Domain.Occasions;
using MediatR;

namespace CopyPara.Application;

public sealed class SetOccasionHandler : IRequestHandler<SetOccasionCommand>
{
    private readonly IAuthDoctor _authDoctor;
    private readonly IOccasionRepository _occasionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITreatmentRepository _treatmentRepository;
    private readonly IMachineRepository _machineRepository;
    private readonly IUtilizationRepository _utilizationRepository;
    private readonly IOccasionScheduler _scheduler;

    public SetOccasionHandler(IAuthDoctor authDoctor,
                              IOccasionRepository occasionRepository,
                              IUnitOfWork unitOfWork,
                              ITreatmentRepository treatmentRepository,
                              IMachineRepository machineRepository,
                              IUtilizationRepository utilizationRepository,
                              IOccasionScheduler scheduler)
    {
        _authDoctor = authDoctor;
        _occasionRepository = occasionRepository;
        _unitOfWork = unitOfWork;
        _machineRepository = machineRepository;
        _treatmentRepository = treatmentRepository;
        _utilizationRepository = utilizationRepository;
        _scheduler = scheduler;
    }

    public async Task Handle(SetOccasionCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _authDoctor.GetAuthenticatedDoctorAsync(cancellationToken);

        if (doctor is null)
        {
            return;
        }

        var treat = await _treatmentRepository.GetTreatmentAsync(request.TreatmentId, cancellationToken);
        var mach = await _scheduler.MachineType(treat, cancellationToken);
        var slot = await _scheduler.TimeSlot(treat.StartDate, treat.StartDate.AddDays(treat.Fraction), treat.Cancer.AvgTimeMins, mach, cancellationToken);

        foreach(var day in EachDay(treat.StartDate, treat.StartDate.AddDays(treat.Fraction)))
        {
            Domain.Occasions.Occasion occasion = new()
            {
                Date = day,
                MachineId = mach.Id,
                TreatmentId = treat.Id,
                TimeSlot = slot
            };

            Domain.Utilizations.Utilization uti = new()
            {
                Date = day,
                MachineId = mach.Id,
                CurrentUtilization = treat.Cancer.AvgTimeMins,
                Slots = Empty.ToList(),

            };

            await _occasionRepository.AddAsync(occasion, cancellationToken);
            await _utilizationRepository.AddAsync(uti, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }


    }

    private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }

    private IEnumerable<Slot> Empty => new List<Slot>()
        {
            new Slot()
            {
                Start=0,
                End=60,
                Type = SlotType.Non
            },
            new Slot()
            {
                Start=60,
                End=120,
                Type = SlotType.Non
            },
            new Slot()
            {
                Start=120,
                End=180,
                Type = SlotType.Non
            },
            new Slot()
            {
                Start=180,
                End=240,
                Type = SlotType.Non
            },
            new Slot()
            {
                Start=240,
                End=300,
                Type = SlotType.Non
            },
            new Slot()
            {
                Start=300,
                End=360,
                Type = SlotType.Non
            },new Slot()
            {
                Start=360,
                End=420,
                Type = SlotType.Non
            },
        };
}
