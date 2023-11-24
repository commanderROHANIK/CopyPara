using CopyPara.Domain.Cancers;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

public class CancerConfiguration  : IEntityTypeConfiguration<Cancer>
{
    public void Configure(EntityTypeBuilder<Cancer> builder)
    {
        builder.HasMany(x => x.Treatments)
            .WithOne(x => x.Cancer);
    }
}