using System.Net;
using SalesApi.Domain.Discounts;
using SalesApi.Domain.Exceptions;

namespace SalesApi.Domain.Sales;

public class SaleProduct
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; }
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
        Discount = CalculateDiscountApplied();
        Total = CalculateTotal();
    }
    
    public void Cancel() => IsCancelled = true;

    private void ValidateMaximumQuantity()
    {
        if(Quantity > 20)
            throw new BusinessException(
                "Invalid Sell",
                HttpStatusCode.BadRequest,
                "You cannot buy more than 20 pieces of same item"
            );
    }
    
    private decimal CalculateTotal() => Quantity * UnitPrice - Discount;
    
    private decimal CalculateDiscountApplied()
    {
        var discountTier = GetDiscountTier();
        
        var discountRate = DiscountTierHelper.GetRate(discountTier);
        
        var total = Quantity * UnitPrice;
        
        return total * discountRate;
    }

    private DiscountTier GetDiscountTier()
    {
        return Quantity switch
        {
            < 4 => DiscountTier.None,
            < 10 => DiscountTier.Tier1,
            < 21 => DiscountTier.Tier2,
            _ => throw new InvalidOperationException()
        };
    }
}