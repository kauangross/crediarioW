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

    [HttpPost("criar")]
    public async Task<IActionResult> CriarClient([FromForm] ClientRequestDto clientRequest)
    {
        return Ok(await _clientService.CreateClient(clientRequest));
    }
}