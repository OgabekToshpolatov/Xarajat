using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Xarajat.Api.Entities;

namespace Xarajat.Api.Data;

public class XarajatDbContext : DbContext
{
    public XarajatDbContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Outlay> Outlays { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);

    //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    // }
}