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
    public async Task<ActionResult<ApiResponse<SaleDto>>> CreateAsync(SaleCreateDto input)
    {
        var sale = await _saleAppService.CreateAsync(input);
        
        var response = new ApiResponse<SaleDto>(sale);

        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ApiResponse<SaleDto>>> GetAsync(Guid id)
    {
        var sale = await _saleAppService.GetAsync(id);
        
        var response = new ApiResponse<SaleDto>(sale);
        
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SaleDto>>>> GetAllAsync()
    {
        var sales = await _saleAppService.GetAllAsync();
        
        var response = new ApiResponse<IEnumerable<SaleDto>>(sales);

        return Ok(response);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteAsync(Guid id)
    {
        await _saleAppService.DeleteAsync(id);
        
        return Ok(new ApiResponse<object>(null!)
        {
            Message = "Sell Cancelled"
        });
    }
}