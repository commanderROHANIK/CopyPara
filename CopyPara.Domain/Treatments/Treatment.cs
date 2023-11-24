using CopyPara.Domain.Patients;
using CopyPara.Domain.Doctors;
using CopyPara.Domain.Occasions;

namespace CopyPara.Domain.Treatments;

public class Treatment
{
    public ulong Id { get; set; }
    public int AvgTimeMins { set; get; }
    public ulong PatientId { get; set; }
    public Patient Patient { get; set; }
    public ulong DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Cancer.Cancer Cancer { get; set; }
    public ulong CancerId { get; set; }
    public List<Occasion> Occasions { get; set; } = [];
}