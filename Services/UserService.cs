namespace crediarioW.Services;

using crediarioW.Models.Entities;
using crediarioW.Dtos;
using crediarioW.Repository;
public class UserService
{
    public readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> CreateAsync(UserRequestDto userRequestDto)
    {
        if (userRequestDto.Email == null || !userRequestDto.Email.Contains("@"))
        {
            throw new ArgumentException("Invalid email format.", nameof(userRequestDto.Email));
        }
    
        if (userRequestDto.PasswordHash == null || userRequestDto.PasswordHash.Length < 6)
        {
            throw new ArgumentException("Password must be at least 6 characters long.", 
                nameof(userRequestDto.PasswordHash));
        }
    
        var user = new User(userRequestDto.Email, userRequestDto.PasswordHash, userRequestDto.Role);
    
        await _userRepository.AddAsync(user);
    
        return user;
    }

    public async Task<User?> ValidateCredentialsAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
    
        if (user == null || user.PasswordHash != password)
        {
            return null; // Invalid credentials
        }
    
        return user; // Valid credentials
    }
}
