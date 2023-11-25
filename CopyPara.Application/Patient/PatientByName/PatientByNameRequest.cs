using MediatR;

namespace CopyPara.Application;

public sealed record class PatientByNameRequest(string Name) : IRequest<IAsyncEnumerable<Domain.Patients.Patient>>;
