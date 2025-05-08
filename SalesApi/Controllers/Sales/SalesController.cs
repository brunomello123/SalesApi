using Microsoft.AspNetCore.Mvc;
using SalesApi.Application.Contracts.Sales;

namespace SalesApi.Controllers.Sales;

[Route("api/sales")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISaleAppService _saleAppService;

    public SalesController(ISaleAppService saleAppService)
    {
        _saleAppService = saleAppService;
    }

    [HttpPost]
    public async Task<ActionResult<SaleDto>> CreateAsync(SaleCreateDto input)
    {
        var product = await _saleAppService.CreateAsync(input);
        
        return Ok(product);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SaleDto>> GetAsync(Guid id)
    {
        var product = await _saleAppService.GetAsync(id);
        
        return Ok(product);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SaleDto>>> GetAllAsync()
    {
        var products = await _saleAppService.GetAllAsync();
        
        return Ok(products);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<IEnumerable<SaleDto>>> DeleteAsync(Guid id)
    {
        await _saleAppService.DeleteAsync(id);
        
        return Ok();
    }
}