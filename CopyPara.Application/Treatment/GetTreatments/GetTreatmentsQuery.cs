using MediatR;

namespace CopyPara.Application.Treatment.GetTreatments;

public record class GetTreatmentsQuery() : IRequest<IEnumerable<DocTreatments>>;
