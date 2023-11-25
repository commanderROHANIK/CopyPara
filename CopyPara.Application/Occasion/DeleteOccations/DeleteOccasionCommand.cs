using MediatR;

namespace CopyPara.Application.Occasion.DeleteOccations;

public record class DeleteOccasionCommand(ulong TreatmentId) : IRequest;
