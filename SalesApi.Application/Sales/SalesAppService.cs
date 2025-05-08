using System.Net;
using AutoMapper;
using SalesApi.Application.Contracts.Sales;
using SalesApi.Domain.Exceptions;
using SalesApi.Domain.Products;
using SalesApi.Domain.Sales;

namespace SalesApi.Application.Sales;

public class SaleAppService(
    ISaleRepository saleRepository,
    IProductRepository productRepository,
    IMapper objectMapper)
    : ISaleAppService
{
    public async Task<SaleDto> CreateAsync(SaleCreateDto input)
    {
        var productSaleIds = input.Products.Select(x => x.ProductId).ToList();
        
        var products = await productRepository.GetByIdsAsync(productSaleIds);

        EnsureAllProductIdsExist(productSaleIds, products);

        var saleId = Guid.NewGuid();

        var saleProducts = BuildSaleProducts(
            saleId,
            input,
            products
        ).ToList();

        var sale = SaleDomainService.Create(
            saleId,
            saleNumber: input.SaleNumber,
            saleDate: input.SaleDate,
            customerId: input.CustomerId,
            branchId: input.BranchId,
            isCancelled: false,
            products: saleProducts
        );

        await saleRepository.InsertAsync(sale);

        return objectMapper.Map<Sale, SaleDto>(sale);
    }

    public async Task<SaleDto> GetAsync(Guid id)
    {
        var sale = await saleRepository.GetAsync(id);

        if (sale is null)
            throw new BusinessException("Entity not found", HttpStatusCode.NotFound);

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
            throw new BusinessException("Entity not found", HttpStatusCode.NotFound);

        sale.Cancel();

        await saleRepository.UpdateAsync(sale);
    }
    
    private static IEnumerable<SaleProduct> BuildSaleProducts(Guid saleId, SaleCreateDto input, List<Product> products)
    {
        var saleProducts = products.Select(product =>
        {
            var dto = input.Products.First(p => p.ProductId == product.Id);

            return new SaleProduct(
                id: Guid.NewGuid(),
                saleId: saleId,
                productId: product.Id,
                quantity: dto.Quantity,
                unitPrice: dto.UnitPrice
            );
        });

        return saleProducts;
    }

    private static void EnsureAllProductIdsExist(IEnumerable<Guid> productSalesIds, List<Product> products)
    {
        var foundIds = products.Select(p => p.Id).ToHashSet();

        var missingIds = productSalesIds.Where(id => !foundIds.Contains(id)).ToList();

        if (missingIds.Count == 0) 
            return;
        
        var idsText = string.Join(", ", missingIds);
        throw new Exception($"Os produtos com os seguintes IDs não foram encontrados: {idsText}");
    }
}