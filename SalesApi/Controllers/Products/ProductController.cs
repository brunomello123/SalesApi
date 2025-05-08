using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Contracts.Products;

namespace SalesApi.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductController(IProductAppService productAppService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<ProductDto>>> CreateAsync(ProductCreateDto input)
    {
        var product = await productAppService.CreateAsync(input);
        
        var response = new ApiResponse<ProductDto>(product);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<ProductDto>>> GetAsync(Guid id)
    {
        var product = await productAppService.GetAsync(id);
        
        var response = new ApiResponse<ProductDto>(product);

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetAllAsync()
    {
        var products = await productAppService.GetAllAsync();
        
        var response = new ApiResponse<IEnumerable<ProductDto>>(products);
        
        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await productAppService.DeleteAsync(id);
        
        return Ok();
    }
}