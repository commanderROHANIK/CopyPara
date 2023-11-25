using MediatR;

namespace CopyPara.Application.Occasion.DeleteOccations;

public sealed class DeleteOccasionsHandler : IRequestHandler<DeleteOccasionCommand>
{
    private readonly IOccasionRepository _occasionRepository;
    private readonly IAuthDoctor _authDoctor;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOccasionsHandler(IOccasionRepository occasionRepository,
                                  IAuthDoctor authDoctor,
                                  IUnitOfWork unitOfWork)
    {
        _occasionRepository = occasionRepository;
        _authDoctor = authDoctor;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteOccasionCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _authDoctor.GetAuthenticatedDoctorAsync(cancellationToken);

        if (doctor is null)
        {
            return;
        }

        await _occasionRepository.DeleteOccasion(doctor.Id, request.TreatmentId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
