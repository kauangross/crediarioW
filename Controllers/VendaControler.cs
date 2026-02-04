using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;
using crediarioW.Models;
using crediarioW.Dtos;

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

    [HttpPost]
    public async Task<IActionResult> CreateVenda([FromBody] VendaRequestDto vendaRequestDto)
    {
        Venda venda = await _vendaService.LancarVenda(vendaRequestDto);

        return Ok(new VendaResponseDto(venda.Id, venda.ClienteId, venda.ValorTotal, venda.Pagamento));
    }

    // GET /vendas/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Venda venda = await _vendaService.GetVendaById(id);
        return Ok(venda);
    }
}