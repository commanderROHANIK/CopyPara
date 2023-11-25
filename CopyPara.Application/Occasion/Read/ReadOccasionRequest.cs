using MediatR;

namespace CopyPara.Application.Patient.Read;

public class ReadOccasionRequest : IRequest<IAsyncEnumerable<Domain.Occasions.Occasion>>;