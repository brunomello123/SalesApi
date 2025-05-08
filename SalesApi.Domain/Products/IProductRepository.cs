namespace SalesApi.Domain.Products;

public interface IProductRepository
{
    Task InsertAsync(Product product);
    Task<Product> GetAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetByIdsAsync(IEnumerable<Guid> ids);
    Task DeleteAsync(Product product);
}