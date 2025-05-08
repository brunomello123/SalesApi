using SalesApi.Domain.Abstractions;

namespace SalesApi.Domain.Sales;

public class Sale : BasicEntity
{
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; private set; }
    public decimal TotalSaleAmount { get; private set; }
    public string Branch { get; private set; }
    public bool IsCancelled { get; private set; }
    public IReadOnlyCollection<SaleProduct> Products { get; private set; }

    internal Sale(
        Guid id,
        string saleNumber,
        DateTime saleDate,
        string customer,
        decimal totalSaleAmount,
        string branch,
        bool isCancelled,
        IEnumerable<SaleProduct> products)
        :base(id)
    {
        SaleNumber = saleNumber ?? throw new ArgumentNullException(nameof(saleNumber));
        SaleDate = saleDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        TotalSaleAmount = totalSaleAmount;
        Branch = branch ?? throw new ArgumentNullException(nameof(branch));
        IsCancelled = isCancelled;
        Products = products.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(products));
    }
}