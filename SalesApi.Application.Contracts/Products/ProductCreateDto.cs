namespace SalesApi.Application.Contracts.Products;

public record ProductCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
}