namespace CopyPara.Application;

public record class DocTreatments
{
    public string PatientName { get; init; } = string.Empty;

    public int Occasions { get; init; }
}
