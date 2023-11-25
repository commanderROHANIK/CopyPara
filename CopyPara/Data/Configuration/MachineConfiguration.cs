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

        builder.HasOne(x => x.Utilization).WithOne(x => x.Machine).HasForeignKey<Utilization>(e => e.MachineId);

        FillData(builder);
    }

    private void FillData(EntityTypeBuilder<Machine> builder)
    {
        builder.HasData([
            new()
            {
                Id = 5,
                Name = "Unique - Clinac",
                MachineTypeId = 1,
            },
            new()
            {
                Id = 3,
                Name = "VitalBeam 1",
                MachineTypeId = 2,
            },
            new()
            {
                Id = 4,
                Name = "VitalBeam 2",
                MachineTypeId = 2,
            },
            new()
            {
                Id = 1,
                Name = "TrueBeam 1",
                MachineTypeId = 3,
            },
            new()
            {
                Id = 2,
                Name = "TrueBeam 2",
                MachineTypeId = 3,
            },
        ]);
    }
}