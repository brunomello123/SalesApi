using System.Net;
using SalesApi.Domain.Exceptions;
using SalesApi.Domain.Taxes;

namespace SalesApi.Domain.Sales;

public class SaleProduct
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal ValueMonetaryTaxApplied { get; }
    public decimal Total { get; }
    public bool IsCancelled { get; private set; }

    public SaleProduct(
        Guid id,
        Guid productId,
        Guid saleId,
        int quantity,
        decimal unitPrice)
    {
        
        Id = id;
        SaleId = saleId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        ValidateMaximumQuantity();
        ValueMonetaryTaxApplied = CalculateMonetaryTaxApplied();
        Total = CalculateTotal();
    }
    
    public void Cancel() => IsCancelled = true;

    private void ValidateMaximumQuantity()
    {
        if(Quantity > 20)
            throw new BusinessException(
                "Invalid Sell",
                HttpStatusCode.BadRequest,
                "You cannot buy more than 20 pices of same item"
            );
    }
    
    private decimal CalculateTotal() => Quantity * UnitPrice - ValueMonetaryTaxApplied;
    private decimal CalculateMonetaryTaxApplied()
    {
        var taxTier = GetTaxTier();
        
        var taxRate = TaxTierRatesHelper.GetRate(taxTier);
        
        var total = Quantity * UnitPrice;
        return total * taxRate;
    }

    private TaxTier GetTaxTier()
    {
        return Quantity switch
        {
            < 4 => TaxTier.None,
            < 10 => TaxTier.Iva,
            < 21 => TaxTier.SpecialIva,
            _ => throw new InvalidOperationException()
        };
    }
}