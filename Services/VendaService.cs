namespace crediarioW.Services;

using System;
using crediarioW.Models;

public class VendaService
{
    public Venda LancarVenda(
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

        return venda;
    }
}

