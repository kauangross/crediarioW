namespace crediarioW.Controllers;

using crediarioW.Dtos;
using crediarioW.Models.Entities;
using crediarioW.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
    [Authorize]
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
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromQuery] Guid id)
    {
        Sale sale = await _saleService.GetSaleByIdAsync(id);
        return Ok(sale);
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Sale> sales = await _saleService.GetAllSalesAsync();
        return Ok(sales);
    }

    [Authorize]
    [HttpGet("clients/{clientId}")]
    public async Task<IActionResult> GetSaleByClientIdAsync([FromRoute] Guid clientId) 
    {
        var sales = await _saleService.GetSaleByClientIdAsync(clientId);
        if(sales is null) return NotFound();
        return Ok(sales);
    }

    [Authorize]
    [HttpGet("dates")]
    public async Task<IActionResult> GetSaleByDateAsync(
        [FromQuery] DateTime startDate, 
        [FromQuery] DateTime endDate)
    {
        var sales = await _saleService.GetSaleByDateAsync(startDate, endDate);

        if(sales is null) return NotFound();
        return Ok(sales);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id)
    {
        if (id == Guid.Empty) return BadRequest("An sale id must be informed.");

        await _saleService.DeleteSaleAsync(id);

        return Ok("Sale deleted.");
    }
}
