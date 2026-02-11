namespace crediarioW.Repository;

using crediarioW.Dtos;
using crediarioW.Infrastructure;
using crediarioW.Models.Entities;
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
    public async Task<Client> UpdateAsync(Guid id, ClientUpdateDto dto)
    {
        var cliente = await _context.Clients.FindAsync(id);

        if (cliente == null) throw new ArgumentNullException("Client não encontrado");

        cliente.UpdateData(dto.NewClientName, dto.NewCpf, dto.NewPhone, dto.NewAddress);

        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task<Client> GetByIdAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) throw new KeyNotFoundException("Client not found.");
       
        return client;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<bool> ClientExists(Guid id)
    {
        return await _context.Clients.AnyAsync(client => client.Id == id);
    }
}