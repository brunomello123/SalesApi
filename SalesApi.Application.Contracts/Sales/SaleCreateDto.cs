namespace SalesApi.Application.Contracts.Sales
{
    public record SaleCreateDto
    {
        public string SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleProductDto> Products { get; set; }
    }
}
