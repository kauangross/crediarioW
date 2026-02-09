namespace crediarioW.Services;

using System;
using System.Threading.Tasks;
using crediarioW.Models.Entities;
using crediarioW.Dtos;
using crediarioW.Repository;
public class SaleService
{
    private readonly SaleRepository _saleRepository;
    private readonly ClientRepository _clientRepository;

    public SaleService(SaleRepository saleRepository, ClientRepository clientRepository)
    {
        _saleRepository = saleRepository;
        _clientRepository = clientRepository;
    }

    public async Task<Sale> CreateSale(SaleRequestDto saleRequestDto)
    {
        if (saleRequestDto.ClientId == Guid.Empty)
        {
            throw new ArgumentException("Invalid ClientId.");
        }

        if (!await _clientRepository.ClientExists(saleRequestDto.ClientId))
        {
            throw new ArgumentException("Client not found.");
        }

        var sale = new Sale(
            saleRequestDto.ClientId,
            saleRequestDto.TotalAmount,
            saleRequestDto.PaymentMethod
        );

        await _saleRepository.AddAsync(sale);

        return sale;
    }

    public async Task<Sale> GetSaleById(Guid id)
    {
        return await _saleRepository.GetByIdAsync(id);
    }
}