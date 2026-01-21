namespace crediarioW.Repository;

using crediarioW.Models;

public class VendaRepository
{
    private readonly AppDbContext _context;

    public VendaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
    }

    public async Task<Venda?> GetByIdAsync(Guid id)
    {
        return await _context.Vendas.FindAsync(id);
    }
}

