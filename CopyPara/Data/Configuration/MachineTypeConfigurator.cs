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

        builder.HasMany<Machine>().WithOne(x => x.MachineType);
        builder.HasMany<Cancer>().WithMany(x => x.MachineTypes);
    }
}