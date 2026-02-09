namespace crediarioW.Dtos;

using crediarioW.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class SaleRequestDto
{
    [Required(ErrorMessage = "Client is required")]
    [JsonPropertyName("clientId")]
    public Guid ClientId { get; set; }

    [Required]
    [Range(0.01, 100000, ErrorMessage = "Total amount must be between 0.01 and 100,000")]
    [JsonPropertyName("totalAmount")]
    public decimal TotalAmount { get; set; }

    [Required]
    [JsonPropertyName("paymentMethod")]
    [EnumDataType(typeof(PaymentMethod))]
    public PaymentMethod PaymentMethod { get; set; }

    public SaleRequestDto() { }
}