namespace crediarioW.Dtos;

using crediarioW.Models;
using System.ComponentModel.DataAnnotations;

public class VendaResponseDto
{
    [Required]
    public Guid Id { get; private set; }
    [Required]
    public Guid ClienteId { get; private set; }
    [Required]
    public decimal ValorTotal { get; private set; }
    [Required]
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

