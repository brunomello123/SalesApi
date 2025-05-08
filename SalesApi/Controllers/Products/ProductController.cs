using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Contracts.Products;

namespace SalesApi.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductAppService _productAppService;

    public ProductController(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateAsync(ProductCreateDto input)
    {
        var product = await _productAppService.CreateAsync(input);
        
        return Ok(product);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetAsync(Guid id)
    {
        var product = await _productAppService.GetAsync(id);
        
        return Ok(product);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync()
    {
        var products = await _productAppService.GetAllAsync();
        
        return Ok(products);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> DeleteAsync(Guid id)
    {
        await _productAppService.DeleteAsync(id);
        
        return Ok();
    }
}