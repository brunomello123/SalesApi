using SalesApi.Domain.Abstractions;

namespace SalesApi.Domain.Sales;

public class Sale : BasicEntity
{
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BranchId { get; private set; }
    public bool IsCancelled { get; private set; }
    public IReadOnlyCollection<SaleProduct> Products { get; private set; }

    internal Sale(
        Guid id,
        string saleNumber,
        DateTime saleDate,
        Guid customerId,
        Guid branchId,
        bool isCancelled,
        IEnumerable<SaleProduct> products)
        :base(id)
    {
        SaleNumber = saleNumber ?? throw new ArgumentNullException(nameof(saleNumber));
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        IsCancelled = isCancelled;
        Products = products.ToList().AsReadOnly() ?? throw new ArgumentNullException(nameof(products));
    }

    public void Cancel()
    {
        IsCancelled = true;

        foreach (var product in Products)
        {
            product.Cancel();
        }
    }
}