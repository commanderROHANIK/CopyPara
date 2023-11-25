using CopyPara.Application.Machine;
using MediatR;

namespace CopyPara.Application.Utilization.Update;

internal sealed class UpdateUtilizationHandler : IRequestHandler<UpdateUtilizationRequest, string>
{
    private readonly IUtilizationRepository _repository;
    private readonly IMachineRepository _machineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUtilizationHandler(IUtilizationRepository repository, IMachineRepository machineRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _machineRepository = machineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(UpdateUtilizationRequest request, CancellationToken cancellationToken)
    {
        var original = await _repository.FindUtilizationAsync(request.Date, request.MachineId);
        var machine = await _machineRepository.GetMachineAsync(request.MachineId, cancellationToken) ?? throw new ArgumentException("A gép nem található az id alapján.");

        if (original != null)
        {
            var initial = original.CurrentUtilization;

            Domain.Utilizations.Utilization uti = new()
            {
                Id = original.Id,
                Date = request.Date,
                MachineId = request.MachineId,
                Machine = machine,
                CurrentUtilization = initial + request.PlusUtilization,

            };

            _repository.Update(uti);
        }
        else
        {
            Domain.Utilizations.Utilization uti = new()
            {
                Date = request.Date,
                MachineId = request.MachineId,
                Machine = machine,
                CurrentUtilization = request.PlusUtilization,
            };

            await _repository.AddAsync(uti,cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Sikeres kihasználtság frissités!";
    }
}
