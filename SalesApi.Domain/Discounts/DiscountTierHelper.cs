namespace SalesApi.Domain.Discounts;

public static class DiscountTierHelper
{
    private static readonly Dictionary<DiscountTier, decimal> Rates = new()
    {
        { DiscountTier.None, 0.0m },
        { DiscountTier.Tier1, 0.10m },
        { DiscountTier.Tier2, 0.20m }
    };

    public static decimal GetRate(DiscountTier tier)
    {
        if (Rates.TryGetValue(tier, out var rate))
            return rate;

        throw new ArgumentOutOfRangeException(nameof(tier), $"Discount tier '{tier}' not recognized.");
    }
}