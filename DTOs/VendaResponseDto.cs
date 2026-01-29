using crediarioW.Models;

namespace crediarioW.Dtos;
public class VendaResponseDto
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public decimal ValorTotal { get; private set; }
    public string Addres { get; private set; }
    public FormaPagamento Pagamento { get; private set; }

    public VendaResponseDto(Guid id, 
        Guid clientId, 
        decimal valor, 
        FormaPagamento pagamento)
    {
        Id = id;
        ClienteId = clientId;
        ValorTotal = valor;
        Pagamento = pagamento;
    }
}

