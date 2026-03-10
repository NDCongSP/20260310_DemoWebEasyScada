using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<RevoConfig> RevoConfigs { get; set; }
    public DbSet<RealtimeData> RealtimeData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RevoConfig>(e =>
        {
            e.Property(x => x.C000).HasMaxLength(4000);
        });
        modelBuilder.Entity<RealtimeData>(e =>
        {
            e.Property(x => x.C00).HasMaxLength(4000);
        });
    }
}
