namespace crediarioW.Dtos;

using crediarioW.Models;
using System.ComponentModel.DataAnnotations;

public class vendaRequestDto
{
    public Guid ClienteId { get; private set; }
    public decimal ValorTotal { get; private set; }
    
    [EnumDataType(typeof(FormaPagamento))]
    public FormaPagamento Pagamento { get; private set; }

    public vendaRequestDto() { }
}