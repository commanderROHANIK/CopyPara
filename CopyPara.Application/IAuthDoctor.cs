using CopyPara.Domain.Doctors;

namespace CopyPara.Application;

public interface IAuthDoctor
{
    Task<Doctor?> GetAuthenticatedDoctorAsync(CancellationToken cancellationToken = default);
}
