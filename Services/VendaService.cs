namespace crediarioW.Services;

using System;
using System.Threading.Tasks;
using crediarioW.Models;
using crediarioW.Dtos;
using crediarioW.Repository;

public class VendaService
{
    private readonly VendaRepository _vendaRepository;

    public VendaService(VendaRepository repository)
    {
        _vendaRepository = repository;
    }

    public async Task<VendaResponseDto> LancarVenda(
        vendaRequestDto vendaRequestDto)
    {

        if(vendaRequestDto.ValorTotal <= 0)
            throw new ArgumentException("Para lançar uma venda, o valor total deve ser maior que zero.", nameof(vendaRequestDto.ValorTotal));

        var venda = new Venda(vendaRequestDto.ClienteId, vendaRequestDto.ValorTotal, vendaRequestDto.Pagamento);
        await _vendaRepository.AddAsync(venda);

        return new VendaResponseDto(venda.Id, venda.ClienteId, venda.ValorTotal, venda.Pagamento);
    }

    public async Task<Venda> GetVendaById(Guid Id)
    {
        return await _vendaRepository.GetByIdAsync(Id);
    }
}