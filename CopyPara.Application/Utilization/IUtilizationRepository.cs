using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Utilization
{
    public interface IUtilizationRepository
    {
        Task AddAsync(Domain.Utilizations.Utilization uti, CancellationToken cancellationToken = default);
        void Update(Domain.Utilizations.Utilization uti);
        Task<Domain.Utilizations.Utilization> FindUtilizationAsync(DateOnly date, ulong machineId, CancellationToken cancellationToken = default);
    }
}
