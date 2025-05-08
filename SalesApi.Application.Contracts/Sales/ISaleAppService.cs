namespace SalesApi.Application.Contracts.Sales;

public interface ISaleAppService
{
    Task<SaleDto> CreateAsync(SaleCreateDto input);

    Task<SaleDto> GetAsync(Guid id);

    Task<IEnumerable<SaleDto>> GetAllAsync();

    Task DeleteAsync(Guid id);
}