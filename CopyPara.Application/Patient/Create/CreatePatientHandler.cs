using CopyPara.Domain.Patients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Patient.Create;

internal sealed class CreatePatientHandler : IRequestHandler<CreatePatientRequest, string>
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<string> Handle(CreatePatientRequest request, CancellationToken cancellationToken)
    {
        Domain.Patients.Patient patient = new()
        {
            Name = request.Name
        };

        await _patientRepository.AddAsync(patient, cancellationToken);

        return "valami";
    }
}
