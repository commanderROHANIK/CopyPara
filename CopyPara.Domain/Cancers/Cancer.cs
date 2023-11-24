using CopyPara.Domain.Treatments;

namespace CopyPara.Domain.Cancer;

public class Cancer
{
    public ulong Id { get; set; }
    public CancerType CancerType { get; set; }
    public ulong TreatmentId { get; set; }
    public Treatment Treatment { get; set; }
}  