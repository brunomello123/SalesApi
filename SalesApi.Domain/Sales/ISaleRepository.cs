namespace SalesApi.Domain.Sales;

public interface ISaleRepository
{
    Task InsertAsync(Sale sale);
    Task<Sale> GetAsync(Guid id);
    Task<List<Sale>> GetAllAsync();
    Task UpdateAsync(Sale sale);
}