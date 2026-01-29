using Microsoft.EntityFrameworkCore;
using crediarioW.Models;

namespace crediarioW.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Venda> Vendas => Set<Venda>();
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

            entity.HasMany(c => c.Vendas)
                  .WithOne(v => v.Cliente)
                  .HasForeignKey(v => v.ClienteId);
        });

        // Venda
        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(v => v.Id);

            entity.Property(v => v.ValorTotal)
                  .HasPrecision(18, 2);

            entity.HasOne(v => v.Cliente)
                  .WithMany(c => c.Vendas)
                  .HasForeignKey(v => v.ClienteId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}