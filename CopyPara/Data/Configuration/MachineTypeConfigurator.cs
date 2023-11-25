using System.IO;
using CopyPara.Domain.Cancers;
using CopyPara.Domain.Machines;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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

        FillData(builder);
    }

    private void FillData(EntityTypeBuilder<MachineType> builder)
    {
        MachineType uc = new()
        {
            Id = 1,
            Type = AcceleratorType.UniqueClinacOneEnergy,
        };

        MachineType vb = new()
        {
            Id = 2,
            Type = AcceleratorType.VitalBeam,
            Features = [
                Features.KVImaging,
                Features.HighFraction
            ],
        };

        MachineType tb = new()
        {
            Id = 3,
            Type = AcceleratorType.TrueBeam,
            Features = [
                Features.HandleLargeBodies,
                Features.BreathHoldingLess,
                Features.KVImaging,
                Features.HighFraction
            ],
        };

        builder.HasData([ uc, vb, tb ]);
    }
}