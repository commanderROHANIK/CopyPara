using CopyPara.Domain.Machines;
using CopyPara.Domain.Utilizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace CopyPara.Data.Configuration;

internal sealed class MachineConfiguration : IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Utilization).WithOne(x => x.Machine).HasForeignKey(e => e.MachineId);
    }
}