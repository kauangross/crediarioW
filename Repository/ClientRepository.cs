namespace crediarioW.Repository;

using crediarioW.Models;
using Microsoft.EntityFrameworkCore;

public class ClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
    }

    public async Task<Client> GetByIdAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            throw new KeyNotFoundException("Client not found.");
        }
        return client;
    }

    public async Task<bool> ClientExists(Guid id)
    {
        return await _context.Clients.AnyAsync(c => c.Id == id);
    }
}