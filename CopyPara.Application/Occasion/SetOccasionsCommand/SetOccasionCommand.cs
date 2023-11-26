using MediatR;

namespace CopyPara.Application.Occasion.SetOccasionsCommand;

public record class SetOccasionCommand(ulong TreatmentId) : IRequest;
