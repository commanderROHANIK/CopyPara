using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Occasion
{
    public interface IOccasionRepository
    {
        Task AddAsync(Domain.Occasions.Occasion occasion, CancellationToken cancellationToken = default);
        ValueTask<Domain.Occasions.Occasion?> GetOccasionAsync(ulong occasionId, CancellationToken cancellationToken = default);
        Task<Domain.Occasions.Occasion[]> GetOccasionsForTreatment(ulong treatmentId, CancellationToken cancellationToken = default);
        Task<Domain.Occasions.Occasion[]> GetOccasionsByDayPerMachine(DateTime date, ulong machineId, CancellationToken cancellationToken = default);
    }
}
