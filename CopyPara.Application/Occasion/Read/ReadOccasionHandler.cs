using CopyPara.Application.Occasion;
using CopyPara.Application.Patient.Create;
using MediatR;

namespace CopyPara.Application.Patient.Read;

public class ReadOccasionHandler : IRequestHandler<ReadOccasionRequest, IAsyncEnumerable<Domain.Occasions.Occasion>>
{
    private readonly IOccasionRepository _occasionRepository;
    
    public ReadOccasionHandler(IOccasionRepository occasionRepository)
    {
        _occasionRepository = occasionRepository;
    }
    
    public Task<IAsyncEnumerable<Domain.Occasions.Occasion>> Handle(ReadOccasionRequest request, CancellationToken cancellationToken)
    {
        var occasions = _occasionRepository.GetAllOccasions();
        return Task.FromResult(occasions);
    }
}