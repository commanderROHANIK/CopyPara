using CopyPara.Domain.Machines;
using CopyPara.Domain.Treatments;

namespace CopyPara.Domain.Cancers;

public class Cancer
{
    public ulong Id { get; set; }

    public int AvgTimeMins { set; get; }

    public CancerType CancerType { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = [];

    public List<MachineType> MachineTypes { get; set; } = [];

}