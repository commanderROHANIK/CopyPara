using CopyPara.Application.Occasion;
using CopyPara.Application.Occasion.SetOccasionsCommand;
using MediatR;

namespace CopyPara.Application;

public sealed class SetOccasionHandler : IRequestHandler<SetOccasionCommand>
{
    private readonly IAuthDoctor _authDoctor;
    private readonly IOccasionRepository _occasionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetOccasionHandler(IAuthDoctor authDoctor,
                              IOccasionRepository occasionRepository,
                              IUnitOfWork unitOfWork)
    {
        _authDoctor = authDoctor;
        _occasionRepository = occasionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SetOccasionCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _authDoctor.GetAuthenticatedDoctorAsync(cancellationToken);

        if (doctor is null)
        {
            return;
        }

        Domain.Occasions.Occasion occasion = new()
        {
            Date = DateTime.Now,
            MachineId = 1,
            TreatmentId = 1,
            TimeSlot = new(5, 9)
        };

        await _occasionRepository.AddAsync(occasion, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
