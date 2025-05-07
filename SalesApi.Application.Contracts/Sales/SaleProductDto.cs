namespace SalesApi.Application.Contracts.Sales
{
    public record SaleProductDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxApplied { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
