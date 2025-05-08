namespace SalesApi.Application.Contracts.Products
{
    public interface IProductAppService
    {
        Task<ProductDto> CreateAsync(ProductCreateDto input);

        Task<ProductDto> GetAsync(Guid id);

        Task<ProductListDto> GetAllAsync();

        Task DeleteAsync(Guid id);
    }
}
