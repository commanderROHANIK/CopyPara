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
        Task CreateAsync(Domain.Treatments.Treatment treatment, CancellationToken cancellationToken = default);
        ValueTask<Cancer?> GetCancerAsync(ulong cancerId, CancellationToken cancellationToken = default);
    }
}
