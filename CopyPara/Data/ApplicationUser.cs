using CopyPara.Domain.Doctors;
using Microsoft.AspNetCore.Identity;

namespace CopyPara.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ulong DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }

}
