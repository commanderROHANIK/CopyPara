using MediatR;

namespace CopyPara.Application.Occasion.DeleteOccations;

public sealed class DeleteOccasionsHandler : IRequestHandler<DeleteOccasionCommand>
{
    private readonly IOccasionRepository _occasionRepository;
    private readonly IAuthDoctor _authDoctor;

    public DeleteOccasionsHandler(IOccasionRepository occasionRepository, IAuthDoctor authDoctor)
    {
        _occasionRepository = occasionRepository;
        _authDoctor = authDoctor;
    }

    public async Task Handle(DeleteOccasionCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _authDoctor.GetAuthenticatedDoctorAsync(cancellationToken);

        if (doctor is null)
        {
            return;
        }

        await _occasionRepository.DeleteOccasion(doctor.Id, request.TreatmentId, cancellationToken);
    }
}
