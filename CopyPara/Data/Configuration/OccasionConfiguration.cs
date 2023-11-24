using CopyPara.Domain.Occasions;
using CopyPara.Domain.Machines;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

internal sealed class OccasionConfiguration : IEntityTypeConfiguration<Occasion>
{
    public void Configure(EntityTypeBuilder<Occasion> builder)
    {
        builder.HasOne(x => x.Treatment)
            .WithMany(x => x.Occasions);

        builder.HasOne(x => x.Machine)
            .WithMany(x => x.Occasions);
    }
}
