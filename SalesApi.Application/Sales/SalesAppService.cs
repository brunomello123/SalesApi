using AutoMapper;
using SalesApi.Application.Contracts.Sales;
using SalesApi.Domain.Exceptions;
using SalesApi.Domain.Sales;

namespace SalesApi.Application.Sales;

public class SaleAppService(
    ISaleDomainService saleDomainService,
    ISaleRepository saleRepository,
    IMapper objectMapper)
    : ISaleAppService
{
    public async Task<SaleDto> CreateAsync(SaleCreateDto input)
    {
        var productSales = input.Products;

        var productsIds = productSales.Select(x => x.ProductId);

        var products = await saleRepository.GetByIdsAsync(productsIds);
        
        var sale = await saleDomainService.CreateAsync(
            Guid.NewGuid(),
            saleNumber: input.SaleNumber,
            saleDate: input.SaleDate,
            customer: input.Customer,
            totalSaleAmount: input.TotalSaleAmount,
            branch: input.Branch,
            isCancelled: input.IsCancelled,
            products:null
        );

        await saleRepository.InsertAsync(sale);

        return objectMapper.Map<Sale, SaleDto>(sale);
    }

    public async Task<SaleDto> GetAsync(Guid id)
    {
        var sale = await saleRepository.GetAsync(id);

        if (sale is null)
            throw new EntityNotFoundException(nameof(Sale));

        return objectMapper.Map<Sale, SaleDto>(sale);
    }

    public async Task<IEnumerable<SaleDto>> GetAllAsync()
    {
        var sales = await saleRepository.GetAllAsync();

        return objectMapper.Map<List<Sale>, List<SaleDto>>(sales);
    }

    public async Task DeleteAsync(Guid id)
    {
        var sale = await saleRepository.GetAsync(id);

        if (sale is null)
            throw new EntityNotFoundException(nameof(Sale));

        await saleRepository.DeleteAsync(sale);
    }
}