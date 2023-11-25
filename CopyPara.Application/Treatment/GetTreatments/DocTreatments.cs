namespace CopyPara.Application;

public record class DocTreatments
{
    public ulong Id { get; init; }

    public string PatientName { get; init; } = string.Empty;

    public int Occasions { get; init; }
}
