using CopyPara.Domain.Cancers;
using CopyPara.Domain.Rooms;
using CopyPara.Domain.Treatments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CopyPara.Data.Configuration;

public sealed class RoomConfiguration  : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasMany(x => x.Patients)
            .WithOne(x => x.Room);
    }
}