namespace SalesApi.Application.Contracts.Products;

public record ProductCreateDto
{
    public required string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxApplied { get; set; }
    public decimal TotalAmount { get; set; }
}