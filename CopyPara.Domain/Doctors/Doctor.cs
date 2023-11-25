using CopyPara.Domain.Treatments;

namespace CopyPara.Domain.Doctors;

public class Doctor
{
    public ulong Id { get; set; }

    public string FirstName { get; set; }
        
    public string LastName { get; set; }
    
    public string ApplicationUserId { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = [];
}
