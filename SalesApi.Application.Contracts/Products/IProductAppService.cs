using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApi.Application.Contracts.Products
{
    public interface IProductAppService
    {
        Task<ProductDto> CreateAsync(ProductCreateDto input);

        Task<ProductDto> GetAsync(Guid id);

        Task<IEnumerable<ProductDto>> GetListAsync();
    }
}
