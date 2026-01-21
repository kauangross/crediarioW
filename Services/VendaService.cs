namespace crediarioW.Services;

using System;
using System.Threading.Tasks;
using crediarioW.Models;
using crediarioW.Repository;

public class VendaService
{
    private readonly VendaRepository _vendaRepository;

    public VendaService(VendaRepository repository)
    {
        _vendaRepository = repository;
    }

    public async Task<Venda> LancarVenda(
        Guid clienteId, 
        decimal valorTotal, 
        int quantidadeParcelas, 
        string pagamento)
    {

        if(valorTotal <= 0)
            throw new ArgumentException("Para lançar uma venda, o valor total deve ser maior que zero.", nameof(valorTotal));

        if (!Enum.TryParse<FormaPagamento>(pagamento, true, out var formaPagamento))
            throw new ArgumentException("Forma de pagamento inválida.", nameof(pagamento));

        Venda venda = new Venda(clienteId, valorTotal, formaPagamento);
        await _vendaRepository.AddAsync(venda);

        return venda;
    }

    public async Task<Venda> GetVendaById(Guid Id)
    {
        return await _vendaRepository.GetByIdAsync(Id);
    }
}

