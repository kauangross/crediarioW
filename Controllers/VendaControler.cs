using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;
using crediarioW.Models;

namespace crediarioW.Controllers;

[ApiController]
[Route("vendas")]
public class VendaController : ControllerBase
{
    private readonly VendaService _vendaService;

    public VendaController(VendaService vendaService)
    {
        _vendaService = vendaService;
    }

    // GET /vendas/teste
    [HttpGet("teste")]
    public async Task<IActionResult> Teste()
    {
        var venda = await _vendaService.LancarVenda(
            Guid.NewGuid(),
            1200m,
            1,
            "CartaoCredito"
        );

        return Ok(venda);
    }

    // GET /vendas/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Venda venda = await _vendaService.GetVendaById(id);
        return Ok(venda);
    }
}