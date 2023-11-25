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

    public string Fractions { get; set; } = string.Empty;

    public int[] GetFractions()
    {
        var splitted = Fractions.Split(',');

        int[] fractions = new int[splitted.Length];
        for(int i = 0; i < splitted.Length; i++)
        {
            fractions[i] = int.TryParse(splitted[i], out int fraction) ? fraction : -1;
        }

        return fractions;
    }
}