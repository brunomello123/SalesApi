namespace SalesApi.Domain.Products;

public interface IProductRepository
{
    Task InsertAsync(Product product);
    Task<Product> GetAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task DeleteAsync(Product product);
}