using MediatR;

namespace CopyPara.Application.Utilization.Update;

public sealed class UpdateUtilizationRequest : IRequest<string>
{
    public DateTime Date { get; set; }
    public ulong MachineId {  get; set; }
    public int PlusUtilization { get; set; }
}