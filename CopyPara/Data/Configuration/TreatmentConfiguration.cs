using CopyPara.Domain.Cancers;
using CopyPara.Domain.Occasions;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasOne<Cancer>()
            .WithOne(x => x.Treatment);

        builder.HasMany<Occasion>()
            .WithOne(x => x.Treatment);
    }
}