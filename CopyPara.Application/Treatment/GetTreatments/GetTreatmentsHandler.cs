using MediatR;

namespace CopyPara.Application.Treatment.GetTreatments;

public sealed class GetTreatmentsHandler : IRequestHandler<GetTreatmentsQuery, IEnumerable<DocTreatments>>
{
    private readonly IAuthDoctor _authDoc;
    private readonly ITreatmentRepository _treatmentRepository;

    public GetTreatmentsHandler(IAuthDoctor authDoc, ITreatmentRepository treatmentRepository)
    {
        _authDoc = authDoc;
        _treatmentRepository = treatmentRepository;
    }

    public async Task<IEnumerable<DocTreatments>> Handle(GetTreatmentsQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _authDoc.GetAuthenticatedDoctorAsync(cancellationToken);

        if (doctor is null)
        {
            return [];
        }

        var treatments = await _treatmentRepository.GetDoctorsTreatments(doctor.Id, cancellationToken);

        return treatments;
    }
}
