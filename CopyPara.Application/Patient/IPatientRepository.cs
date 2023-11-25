using CopyPara.Domain.Patients;

namespace CopyPara.Application.Patient;

public interface IPatientRepository
{
    Task AddAsync(Domain.Patients.Patient patient, CancellationToken cancellationToken = default);
    ValueTask<Domain.Patients.Patient?> GetPatientAsync(ulong patientId, CancellationToken cancellationToken = default);
    IAsyncEnumerable<Domain.Patients.Patient> SearchByName(string name);
}
