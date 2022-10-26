using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xarajat.Api.Entities.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("integer").ValueGeneratedOnAdd();
        builder.Property(b => b.Name).HasColumnType("varchar(50)").IsRequired(true);
        builder.Property(b => b.Key).IsRequired(true);
        builder.Property(b => b.AdminId).IsRequired(true);
    }
}