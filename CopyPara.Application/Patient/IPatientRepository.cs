using CopyPara.Domain.Patients;

namespace CopyPara.Application.Patient;

public interface IPatientRepository
{
    Task AddAsync(Domain.Patients.Patient patient, CancellationToken cancellationToken = default);
}
