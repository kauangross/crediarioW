using Microsoft.EntityFrameworkCore;
using crediarioW.Models;

namespace crediarioW.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Venda> Vendas => Set<Venda>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
