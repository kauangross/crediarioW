namespace crediarioW.Dtos;

using crediarioW.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class SaleResponseDto
{
    [Required]
    public Guid Id { get; private set; }

    [Required]
    public Guid ClientId { get; private set; }

    [Required]
    public decimal TotalAmount { get; private set; }

    [Required]
    public PaymentMethod PaymentMethod { get; private set; }

    public SaleResponseDto(
        Guid id,
        Guid clientId,
        decimal totalAmount,
        PaymentMethod paymentMethod)
    {
        Id = id;
        ClientId = clientId;
        TotalAmount = totalAmount;
        PaymentMethod = paymentMethod;
    }
}