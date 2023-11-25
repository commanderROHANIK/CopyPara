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
        Task<Domain.Utilizations.Utilization> FindUtilizationAsync(DateTime date, ulong machineId, CancellationToken cancellationToken = default);
        Task<int> GetUtilizationSum(DateTime start, DateTime end, ulong machineId, CancellationToken cancellationToken = default);
        Task<List<(ulong, int)>> GetUtilization(DateTime start, DateTime end, CancellationToken cancellationToken = default);

    }
}
