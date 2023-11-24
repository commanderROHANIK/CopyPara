using CopyPara.Domain.Machines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

internal sealed class MachineConfiguration : IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> builder)
    {
        builder.HasKey(x => x.Id);
    }
}