using CopyPara.Domain.Occasions;
using CopyPara.Domain.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

internal sealed class OccasionConfiguration : IEntityTypeConfiguration<Occasion>
{
    public void Configure(EntityTypeBuilder<Occasion> builder)
    {
        builder.HasOne<Machine>()
            .WithMany(x => x.Occasion);

        builder.HasOne<Treatment>()
            .WithMany(x => x.Occasion);
    }
}
