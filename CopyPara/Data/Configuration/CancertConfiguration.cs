using CopyPara.Domain.Cancer;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

public class CancertConfiguration  : IEntityTypeConfiguration<Cancer>
{
    public void Configure(EntityTypeBuilder<Cancer> builder)
    {
        builder.HasOne<Treatment>()
            .WithOne(x => x.Cancer);
    }
}