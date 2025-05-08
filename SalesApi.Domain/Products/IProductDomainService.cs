namespace SalesApi.Domain.Products;

public interface IProductDomainService
{
    Task<Product> CreateAsync(
        Guid id,
        string title,
        string description,
        string category,
        string image,
        decimal price
    );
}