using SalesApi.Domain.Abstractions;

namespace SalesApi.Domain.Products;

public class Product : BasicEntity
{
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TaxApplied { get; private set; }
    public decimal TotalAmount { get; private set; }

    internal Product(
        Guid id,
        string productName,
        int quantity,
        decimal unitPrice,
        decimal taxApplied,
        decimal totalAmount
        ) : base(id)
    {
        ProductName = !string.IsNullOrWhiteSpace(productName)
            ? productName
            : throw new ArgumentException("Product name is required.", nameof(productName));

        if (quantity < 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");

        if (unitPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");

        if (taxApplied < 0)
            throw new ArgumentOutOfRangeException(nameof(taxApplied), "Tax applied cannot be negative.");

        if (totalAmount < 0)
            throw new ArgumentOutOfRangeException(nameof(totalAmount), "Total amount cannot be negative.");

        Quantity = quantity;
        UnitPrice = unitPrice;
        TaxApplied = taxApplied;
        TotalAmount = totalAmount;
    }

    protected Product() { }
}
