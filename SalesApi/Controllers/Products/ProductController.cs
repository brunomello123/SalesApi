using Microsoft.AspNetCore.Mvc;

namespace SalesApi.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> GetAllAsync()
    {
        return Ok();
    }
}