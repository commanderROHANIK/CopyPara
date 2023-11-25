using CopyPara.Application.Machine;
using MediatR;

namespace CopyPara.Application.Utilization.Create;

internal sealed class CreateUtilizationHandler : IRequestHandler<CreateUtilizationRequest, string>
{
    private readonly IUtilizationRepository _repository;
    private readonly IMachineRepository _machineRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUtilizationHandler(IUtilizationRepository repository, IMachineRepository machineRepository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _machineRepository = machineRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateUtilizationRequest request, CancellationToken cancellationToken)
    {
        var machine = await _machineRepository.GetMachineAsync(request.MachineId, cancellationToken) ?? throw new ArgumentException("A gép nem található az id alapján.");

        Domain.Utilizations.Utilization uti = new()
        {
            Date = request.Date,
            MachineId = request.MachineId,
            Machine = machine,
            CurrentUtilization = request.InitialUtilization,
        };

        await _repository.AddAsync(uti, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return "Sikeres kihasználtság létrehozás!";
    }
}
