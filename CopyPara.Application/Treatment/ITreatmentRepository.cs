using CopyPara.Domain.Cancers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Treatment
{
    public interface ITreatmentRepository
    {
        Task AddAsync(Domain.Treatments.Treatment treatment, CancellationToken cancellationToken = default);
        ValueTask<Domain.Cancers.Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default);
        ValueTask<Domain.Treatments.Treatment?> GetTreatmentAsync(ulong treatmentId, CancellationToken cancellationToken = default);
    }
}
