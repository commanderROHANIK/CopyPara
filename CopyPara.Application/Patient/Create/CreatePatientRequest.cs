using CopyPara.Domain.Patients.Enums;
using MediatR;

namespace CopyPara.Application.Patient.Create;

public sealed class CreatePatientRequest : IRequest<ulong>
{
    public string Name { get; init; } = string.Empty;
    public Condition Condition { get; set; }
    public Sex Sex { get; set; }

}