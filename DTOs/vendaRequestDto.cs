namespace crediarioW.Dtos;

using crediarioW.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class VendaRequestDto
{
    [Required(ErrorMessage = "O cliente é obrigatório")]
    [JsonPropertyName("clienteId")] // O Swagger agora vai exigir "clientId"
    public Guid ClienteId { get; set; }
    
    [Required]
    [Range(0.01, 100000, ErrorMessage = "O valor deve ser entre 0.01 e 100.000")]
    [JsonPropertyName("valorTotal")]
    public decimal ValorTotal { get; set; }
    
    [Required]
    [JsonPropertyName("pagamento")]
    [EnumDataType(typeof(FormaPagamento))]
    public FormaPagamento Pagamento { get; set; }

    public VendaRequestDto() { }
}