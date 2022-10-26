using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Xarajat.Api.Entities.Configurations;


public class OutlayConfiguration : IEntityTypeConfiguration<Outlay>
{
    public void Configure(EntityTypeBuilder<Outlay> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("integer").ValueGeneratedOnAdd();
        builder.Property(b => b.Description).HasColumnType("nvarchar(250)").IsRequired(true);
        builder.Property(b => b.Cost).IsRequired(true);
        builder.Property(b => b.UserId).IsRequired(true);
        builder.Property(b => b.RoomId).IsRequired(true);
    }
}