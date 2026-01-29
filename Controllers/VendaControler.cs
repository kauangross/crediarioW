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

    // GET /vendas/teste
    [HttpGet("teste")]
    public async Task<IActionResult> Teste()
    {
       var vendaDto = new vendaRequestDto(
            Guid.NewGuid(), // Id de cliente existente
            1500m,
            FormaPagamento.Dinheiro
        );
        
        VendaResponseDto vendaResponseDto = await _vendaService.LancarVenda(vendaDto);

        return Ok(vendaResponseDto);
    }

    // GET /vendas/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Venda venda = await _vendaService.GetVendaById(id);
        return Ok(venda);
    }
}