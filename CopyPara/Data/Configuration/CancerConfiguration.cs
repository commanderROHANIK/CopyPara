using CopyPara.Domain.Cancers;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

public sealed class CancerConfiguration  : IEntityTypeConfiguration<Cancer>
{
    public void Configure(EntityTypeBuilder<Cancer> builder)
    {
        builder.HasMany(x => x.Treatments)
            .WithOne(x => x.Cancer);

        FillData(builder);
    }

    private void FillData(EntityTypeBuilder<Cancer> builder)
    {
        builder.HasData([
            new()
            {
                Id = 1,
                CancerType = CancerType.ABDOMEN,
                AvgTimeMins = 12,
                Fractions = "5,10,12"
            },
            new()
            {
                Id = 2,
                CancerType = CancerType.BREAST,
                AvgTimeMins = 12,
                Fractions = "5,10,12"
            },
            new()
            {
                Id = 3,
                CancerType = CancerType.BREAST_SPECIAL,
                AvgTimeMins = 20,
                Fractions = "5,10,12"
            },
            new()
            {
                Id = 4,
                CancerType = CancerType.CRANE,
                AvgTimeMins = 10,
                Fractions = "1,5,10,13,25,30"
            },
            new()
            {
                Id = 5,
                CancerType = CancerType.CRANIOSPINAL,
                AvgTimeMins = 30,
                Fractions = "13,17,20,30"
            },
            new()
            {
                Id = 6,
                CancerType = CancerType.HEAD_AND_NECK,
                AvgTimeMins = 12,
                Fractions = "5,10,15,25,30,33,35"
            },
            new()
            {
                Id = 7,
                CancerType = CancerType.LUNG,
                AvgTimeMins = 12,
                Fractions = "1,5,10,15,20,25,30,33"
            },
            new()
            {
                Id = 8,
                CancerType = CancerType.LUNG_SPECIAL,
                AvgTimeMins = 15,
                Fractions = "3,5,8"
            },
            new()
            {
                Id = 9,
                CancerType = CancerType.PELVIS,
                AvgTimeMins = 12,
                Fractions = "1,3,5,10,15,22,23,25,28,35"
            },
            new()
            {
                Id = 10,
                CancerType = CancerType.WHOLE_BRAIN,
                AvgTimeMins = 10,
                Fractions = "5,10,12"
            },
        ]);
    }
}