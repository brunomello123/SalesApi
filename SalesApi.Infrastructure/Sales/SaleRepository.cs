using MongoDB.Driver;
using SalesApi.Domain.Sales;

namespace SalesApi.Infrastructure.Sales;

public class SaleRepository(IMongoDatabase database): ISaleRepository
{
    private readonly IMongoCollection<Sale> _sales = database.GetCollection<Sale>("sales");

    public async Task InsertAsync(Sale sale) => await _sales.InsertOneAsync(sale);
    public async Task<Sale> GetAsync(Guid id) => await _sales.Find(s => s.Id == id).FirstOrDefaultAsync();
    public async Task<List<Sale>> GetAllAsync() => await _sales.Find(_ => true).ToListAsync();
    
    public async Task<List<Sale>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        var filter = Builders<Sale>.Filter.In(sale => sale.Id, ids);
        return await _sales.Find(filter).ToListAsync();
    }

    public async Task DeleteAsync(Sale sale) => await _sales.DeleteOneAsync(s => s.Id == sale.Id);
}