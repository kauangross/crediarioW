namespace crediarioW.Controllers;

using crediarioW.Dtos;
using crediarioW.Models.Entities;
using crediarioW.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    public readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserRequestDto userRequestDto)
    {
        User user = await _userService.CreateAsync(userRequestDto);

        return Ok(new UserResponseDto(
            user.Id,
            user.Email,
            user.Role));
    }
}
