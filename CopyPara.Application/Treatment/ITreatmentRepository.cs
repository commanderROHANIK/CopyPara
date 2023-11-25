using CopyPara.Domain.Cancers;

namespace CopyPara.Application.Treatment
{
    public interface ITreatmentRepository
    {
        Task AddAsync(Domain.Treatments.Treatment treatment, CancellationToken cancellationToken = default);
        Task<GetCancer.Cancer[]> GetCancersForSelectAsync(CancellationToken cancellationToken = default);
        ValueTask<Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default);
        ValueTask<Domain.Treatments.Treatment?> GetTreatmentAsync(ulong treatmentId, CancellationToken cancellationToken = default);
        Task<Domain.Treatments.Treatment[]> GetAllTreatment(CancellationToken cancellationToken = default);
    }
}
