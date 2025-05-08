namespace SalesApi.Application.Contracts.Products
{
    public interface IProductAppService
    {
        Task<ProductDto> CreateAsync(ProductCreateDto input);

        Task<ProductDto> GetAsync(Guid id);

        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task DeleteAsync(Guid id);
    }
}
