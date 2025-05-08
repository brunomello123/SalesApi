namespace SalesApi.Application.Contracts.Sales;

public record SaleProductDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}