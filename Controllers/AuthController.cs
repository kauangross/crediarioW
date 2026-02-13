using crediarioW.Dtos;
using crediarioW.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crediarioW.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService; 
    private readonly TokenService _tokenService;

    public AuthController(UserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto LoginRequestodto)
    {
        var user = await _userService.ValidateCredentialsAsync(
            LoginRequestodto.Email, 
            LoginRequestodto.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _tokenService.Generate(user);

        return Ok(new
        {
            access_token = token
        });
    }

}