using MediatR;

namespace CopyPara.Application.Utilization.Create;

public sealed class CreateUtilizationRequest : IRequest<string>
{
    public DateOnly Date { get; set; }
    public ulong MachineId {  get; set; }
    public int InitialUtilization { get; set; }
}