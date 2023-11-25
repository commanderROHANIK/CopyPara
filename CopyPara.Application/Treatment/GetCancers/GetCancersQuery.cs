using MediatR;

namespace CopyPara.Application.Treatment.GetCancer;

public sealed record GetCancersQuery() : IRequest<IEnumerable<Cancer>>;
