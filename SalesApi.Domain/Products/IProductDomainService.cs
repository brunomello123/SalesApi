namespace SalesApi.Domain.Products;

public interface IProductDomainService
{
    Task<Product> CreateAsync(
        Guid id,
        string productName,
        int quantity,
        decimal unitPrice,
        decimal taxApplied,
        decimal totalAmount
        );
}