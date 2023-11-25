using MediatR;

namespace CopyPara.Application.Treatment.GetCancer;

public sealed class GetCancersQueryHandler : IRequestHandler<GetCancersQuery, IEnumerable<Cancer>>
{
    private readonly ITreatmentRepository _treatmentRepository;

    public GetCancersQueryHandler(ITreatmentRepository treatmentRepository)
    {
        _treatmentRepository = treatmentRepository;
    }

    public async Task<IEnumerable<Cancer>> Handle(GetCancersQuery request, CancellationToken cancellationToken)
    {
        var cancers = await _treatmentRepository.GetCancersForSelectAsync(cancellationToken);

        return cancers;
    }
}
