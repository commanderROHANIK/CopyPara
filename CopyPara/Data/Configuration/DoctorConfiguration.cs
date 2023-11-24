using CopyPara.Data;
using CopyPara.Domain.Doctors;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara;

public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasOne<ApplicationUser>()
            .WithOne(x => x.Doctor);

        builder.HasMany<Treatment>()
            .WithOne(x => x.Doctor);
    }
}
