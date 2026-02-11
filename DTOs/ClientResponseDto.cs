using System.ComponentModel.DataAnnotations;

namespace crediarioW.Dtos;

public class ClientResponseDto
{
    [Required]
    public Guid Id { get; }
    [Required]
    [MaxLength(150)]
    public string ClientName { get; set; } = null!;
    [MaxLength(11)]
    public string? Cpf { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public ClientResponseDto(Guid id, 
        string clientName, 
        string? cpf,
        string? phone, 
        string? adress)
    {
        Id = id;
        ClientName = clientName;
        Cpf = cpf ?? null;
        Phone = phone ?? null;
        Address = adress ?? null;
    }
}
