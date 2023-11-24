namespace CopyPara.Domain;

public class Doctor
{
    public ulong Id { get; set; }

    public string ApplicationUserId { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = [];
}
