namespace crediarioW.Dtos;

using System.ComponentModel.DataAnnotations;

public class UserRequestDto
{
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    [Required]
    public required string Role { get; set; }

    public UserRequestDto() { }
}
