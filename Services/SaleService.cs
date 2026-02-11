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

    public async Task<Sale> GetSaleByIdAsync(Guid id)
    {
        Sale? sale = await _saleRepository.GetByIdAsync(id);

        if(sale is null) throw new KeyNotFoundException("Sale not found.");
        return sale;
    }
    public async Task<IEnumerable<Sale>> GetAllSalesAsync()
    {
        return await _saleRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Sale>> GetSaleByClientIdAsync(Guid clientId)
    {
        return await _saleRepository.GetSaleByClientIdAsync(clientId);
    }

    public async Task<IEnumerable<Sale>> GetSaleByDateAsync(DateTime startDate, DateTime endDate)
    {
        if(startDate == DateTime.MinValue) 
            throw new ArgumentNullException("Start date must be informed");
        
        if (endDate == DateTime.MinValue) endDate = DateTime.UtcNow;

        if (startDate > endDate) 
            throw new ArgumentException("Start date must be less than or equal to end date.");

        return await _saleRepository.GetSaleByDateAsync(startDate, endDate);
    }
}