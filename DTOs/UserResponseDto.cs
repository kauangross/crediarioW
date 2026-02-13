namespace crediarioW.Dtos;

public class UserResponseDto
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = null!;
    public string Role { get; private set; } = null!;

    public UserResponseDto(Guid id, string email, string role) 
    {
        Id = id;
        Email = email;
        Role = role;
    }
}
