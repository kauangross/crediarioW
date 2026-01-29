namespace crediarioW.Dtos;

using System.ComponentModel.DataAnnotations;

public class ClientRequestDto
{
    [Required]
    [MaxLength(150)]
    public string ClientName { get; set; } = null!;
    [MaxLength(11)]
    public string? Cpf { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public ClientRequestDto() { }
}
