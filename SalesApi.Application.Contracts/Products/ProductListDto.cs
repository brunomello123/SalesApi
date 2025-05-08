namespace SalesApi.Application.Contracts.Products;

public class ProductListDto
{
    public IEnumerable<ProductDto> Data { get; set; }
}