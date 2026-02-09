using Microsoft.EntityFrameworkCore;
using crediarioW.Models.Entities;

namespace crediarioW.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Client> Clients => Set<Client>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Client
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.ClientName)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.HasMany(c => c.Sales)
                  .WithOne(s => s.Client)
                  .HasForeignKey(s => s.ClientId);
        });

        // Sale
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.TotalAmount)
                  .HasPrecision(18, 2);

            entity.HasOne(s => s.Client)
                  .WithMany(c => c.Sales)
                  .HasForeignKey(s => s.ClientId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}