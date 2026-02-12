namespace crediarioW.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;
using crediarioW.Dtos;

[ApiController]
[Route("clients")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientRequestDto clientRequestDto)
    {
        var result = await _clientService.CreateAsync(clientRequestDto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ClientUpdateDto updateRequestDto)
    {
        var result = await _clientService.UpdateAsync(id, updateRequestDto);

        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _clientService.GetByIdAsync(id);

        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var clientsList = await _clientService.GetAllAsync();
 
        if (clientsList == null) return NotFound();
        return Ok(clientsList);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        if(id == Guid.Empty) return BadRequest("An client id must be informed");

        await _clientService.DeleteAsync(id);

        return Ok("Client deleted successfully.");
    }
}