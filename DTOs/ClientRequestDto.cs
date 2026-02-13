namespace crediarioW.Dtos;

using System.ComponentModel.DataAnnotations;

public class ClientRequestDto
{
    [MaxLength(150)]
    [Required]
    public required string ClientName { get; set; }
    [MaxLength(11)]
    public string? Cpf { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public ClientRequestDto() { }
}
