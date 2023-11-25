using CopyPara.Domain.Patients;
using MediatR;

namespace CopyPara.Application.Patient.Create;

public sealed class CreatePatientRequest : IRequest<string>
{
    public string Name { get; init; } = string.Empty;
    public Condition Condition { get; set; }
    public string Gender { get; set; }

}