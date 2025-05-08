using AutoMapper;
using SalesApi.Application.Contracts.Products;
using SalesApi.Domain.Exceptions;
using SalesApi.Domain.Products;

namespace SalesApi.Application.Products
{
    public class ProductAppService(
        IProductDomainService productDomainService,
        IProductRepository productRepository,
        IMapper objectMapper)
        : IProductAppService
    {
        public async Task<ProductDto> CreateAsync(ProductCreateDto input)
        {
            var product = await productDomainService.CreateAsync(
                id: Guid.NewGuid(),
                productName: input.ProductName,
                quantity: input.Quantity,
                unitPrice: input.UnitPrice,
                taxApplied: input.TaxApplied,
                totalAmount: input.TotalAmount
            );

            await productRepository.InsertAsync(product);

            return objectMapper.Map<Product, ProductDto>(product);
        }
        
        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await productRepository.GetAsync(id);
            
            return objectMapper.Map<Product, ProductDto>(product);
        }
        
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await productRepository.GetAllAsync();
            
            return objectMapper.Map<List<Product>, List<ProductDto>>(products);
        }
        
        public async Task DeleteAsync(Guid id)
        {
            var product = await productRepository.GetAsync(id);
            
            if(product is null)
                throw new EntityNotFoundException(nameof(Product));

            await productRepository.DeleteAsync(product);
        }
    }
}
