using CopyPara.Application.Patient;
using MediatR;

namespace CopyPara.Application;

public sealed class PatientByNameHandler : IRequestHandler<PatientByNameRequest, IAsyncEnumerable<Domain.Patients.Patient>>
{
    private readonly IPatientRepository _patientRepository;

    public PatientByNameHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public Task<IAsyncEnumerable<Domain.Patients.Patient>> Handle(PatientByNameRequest request, CancellationToken cancellationToken)
    {
        var patients = _patientRepository.SearchByName(request.Name);

        return Task.FromResult(patients);
    }
}
