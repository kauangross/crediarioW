using Microsoft.AspNetCore.Mvc;
using crediarioW.Services;
using crediarioW.Models.Entities;
using crediarioW.Dtos;

namespace crediarioW.Controllers;

[ApiController]
[Route("sales")]
public class SaleController : ControllerBase
{
    private readonly SaleService _saleService;

    public SaleController(SaleService saleService)
    {
        _saleService = saleService;
    }

    // POST /sales
    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] SaleRequestDto saleRequestDto)
    {
        Sale sale = await _saleService.CreateSale(saleRequestDto);

        return Ok(new SaleResponseDto(
            sale.Id,
            sale.ClientId,
            sale.TotalAmount,
            sale.PaymentMethod
        ));
    }

    // GET /sales/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        Sale sale = await _saleService.GetSaleById(id);
        return Ok(sale);
    }
}
