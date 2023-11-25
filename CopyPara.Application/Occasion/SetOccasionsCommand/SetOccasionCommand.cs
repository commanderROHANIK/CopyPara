using MediatR;

namespace CopyPara.Application.Occasion.SetOccasionsCommand;

public record class SetOccasionCommand(ulong DoctorId) : IRequest;
