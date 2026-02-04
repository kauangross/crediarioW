namespace crediarioW.Services;

using System;
using System.Threading.Tasks;
using crediarioW.Models;
using crediarioW.Dtos;
using crediarioW.Repository;

public class VendaService
{
    private readonly VendaRepository _vendaRepository;
    private readonly ClientRepository _clientRepository;

    public VendaService(VendaRepository repository, ClientRepository clientRepository)
    {
        _vendaRepository = repository;
        _clientRepository = clientRepository;
    }

    public async Task<Venda> LancarVenda(
        VendaRequestDto vendaRequestDto)
    {
        var venda = new Venda(vendaRequestDto.ClienteId, vendaRequestDto.ValorTotal, vendaRequestDto.Pagamento);

        if(vendaRequestDto.ClienteId == Guid.Empty) // Precisa validar se cliente existe no banco
        {
            throw new ArgumentException("ClienteId inválido.");
        } 

        if(!(await _clientRepository.ClientExists(vendaRequestDto.ClienteId)))
        {
            throw new ArgumentException("Cliente não encontrado.");
        }

        await _vendaRepository.AddAsync(venda);

        return venda;
    }

    public async Task<Venda> GetVendaById(Guid Id)
    {
        return await _vendaRepository.GetByIdAsync(Id);
    }
}