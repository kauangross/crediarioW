namespace crediarioW.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;

using crediarioW.Models;

[ApiController]
[Route("clients")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    // GET /clients/teste
    [HttpGet("teste")]
    public IActionResult Teste()
    {
        var client = _clientService.CreateClient(
            Guid.NewGuid(),
            "Kauan",
            "03709832039",
            "51997317533",
            "Igrejinha"
        );

        var client2 = _clientService.CreateClient( 
            Guid.NewGuid(),
            "Rosi",
            "03709832039",
            "51997317533",
            "Taquara"
        );

        List<Client> clients = new();

        clients.Add(client);
        clients.Add(client2);

        return Ok(clients);
    }
}