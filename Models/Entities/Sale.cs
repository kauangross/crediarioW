namespace crediarioW.Models.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using crediarioW.Models.Enums;

public class Sale
{
    [Required]
    public Guid Id { get; private set; }

    [Required]
    public Guid ClientId { get; private set; }

    [Required]
    public Client Client { get; private set; }

    [Required]
    public decimal TotalAmount { get; private set; }

    [Required]
    public DateTime SaleDate { get; private set; }

    [Required]
    public PaymentMethod PaymentMethod { get; private set; }

    protected Sale() { } // EF Core

    public Sale(Guid clientId, decimal totalAmount, PaymentMethod paymentMethod)
    {
        Id = Guid.NewGuid();
        ClientId = clientId;
        SaleDate = DateTime.UtcNow;
        TotalAmount = totalAmount;
        PaymentMethod = paymentMethod;
    }
}