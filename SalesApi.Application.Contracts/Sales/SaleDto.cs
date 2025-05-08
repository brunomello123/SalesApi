namespace SalesApi.Application.Contracts.Sales;

public class SaleDto
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid BranchId { get; set; }
    public bool IsCancelled { get; set; }
    public List<SaleProductDto> Products { get; set; }
}