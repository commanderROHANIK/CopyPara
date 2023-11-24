using CopyPara.Domain.Cancers;
using CopyPara.Domain.Machines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

internal sealed class MachineTypeConfiguration : IEntityTypeConfiguration<MachineType>
{
    public void Configure(EntityTypeBuilder<MachineType> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasMany(x => x.Machines)
            .WithOne(x => x.MachineType)
            .HasForeignKey(x => x.MachineTypeId);

        builder.HasMany(x => x.Cancers).WithMany(x => x.MachineTypes);
    }
}