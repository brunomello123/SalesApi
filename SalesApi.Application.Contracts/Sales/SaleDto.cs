namespace SalesApi.Application.Contracts.Sales
{
    public class SaleDto
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public string Branch { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleProductDto> Products { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
