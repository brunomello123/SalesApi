namespace SalesApi.Domain.Sales;

public class SaleProduct
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TaxApplied { get; set; }
    public decimal TotalAmount { get; set; }
}