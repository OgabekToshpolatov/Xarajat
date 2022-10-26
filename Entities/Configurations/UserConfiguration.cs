using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Xarajat.Api.Entities.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnType("integer").ValueGeneratedOnAdd();
        builder.Property(b => b.Name).HasColumnType("varchar(50)").IsRequired(true);
        builder.Property(b => b.Phone).IsRequired();
        builder.Property(b => b.RoomId).IsRequired();
    }
}