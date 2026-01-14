using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;

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
    public IActionResult Teste()
    {
        var venda = _vendaService.LancarVenda(
            Guid.NewGuid(),
            1200m,
            1,
            "CartaoCredito"
        );

        return Ok(new
        {
            venda.Id,
            venda.DataVenda,
            venda.ValorTotal,
            venda.Pagamento
        });
    }
}