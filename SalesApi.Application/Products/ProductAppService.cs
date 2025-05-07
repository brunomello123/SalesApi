using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApi.Application.Contracts.Products;
using SalesApi.Domain.Products;

namespace SalesApi.Application.Products
{
    public class ProductAppService: IProductAppService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductRepository _productRepository;

        public ProductAppService(
            IProductDomainService productDomainService,
            IProductRepository productRepository)
        {
            _productDomainService = productDomainService;
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto input)
        {
            var product = await _productDomainService.CreateAsync(
                id: Guid.NewGuid(),
                productName: input.ProductName,
                quantity: input.Quantity,
                unitPrice: input.UnitPrice,
                taxApplied: input.TaxApplied,
                totalAmount: input.TotalAmount
            );

            product = await _productRepository.InsertAsync(product);
            
            //Mapper here
            
            return new ProductDto();
        }
        
        public async Task<ProductDto> GetAsync(Guid id)
        {
            await Task.CompletedTask;
            return new ProductDto();
        }
        
        public async Task<IEnumerable<ProductDto>> GetListAsync()
        {
            await Task.CompletedTask;
            return new List<ProductDto>();
        }
    }
}
