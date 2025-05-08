using MongoDB.Driver;
using SalesApi.Domain.Products;

namespace SalesApi.Infrastructure.Products;

public class ProductRepository(IMongoDatabase database) : IProductRepository
{
    private readonly IMongoCollection<Product> _products = database.GetCollection<Product>("products");

    public async Task InsertAsync(Product product) => await _products.InsertOneAsync(product);
    public async Task<Product> GetAsync(Guid id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    public async Task<List<Product>> GetAllAsync() => await _products.Find(_ => true).ToListAsync();
    public async Task DeleteAsync(Product product) => await _products.DeleteOneAsync(p => p.Id == product.Id);
}