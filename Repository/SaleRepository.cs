namespace crediarioW.Repository;

using crediarioW.Infrastructure;
using crediarioW.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class SaleRepository
{
    private readonly AppDbContext _context;

    public SaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {

        return await _context.Sales.FindAsync(id);
    }
    public async Task<List<Sale>> GetAllAsync()
    {
        return await _context.Sales.ToListAsync();
    }

    public async Task<List<Sale>> GetSaleByClientIdAsync(Guid id)
    {
        return await _context.Sales.Where(sale => sale.ClientId == id).ToListAsync();
    }

    public async Task<List<Sale>> GetSaleByDateAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Sales.Where(sale => sale.SaleDate >= startDate 
            && sale.SaleDate <= endDate).ToListAsync();
    }

    public async Task DeleteAsync(Sale sale)
    {
        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();
    }
}
