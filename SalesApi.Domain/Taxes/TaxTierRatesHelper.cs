namespace SalesApi.Domain.Taxes;

public static class TaxTierRatesHelper
{
    private static readonly Dictionary<TaxTier, decimal> Rates = new()
    {
        { TaxTier.None, 0.0m },
        { TaxTier.Iva, 0.10m },
        { TaxTier.SpecialIva, 0.20m }
    };

    public static decimal GetRate(TaxTier tier)
    {
        if (Rates.TryGetValue(tier, out var rate))
            return rate;

        throw new ArgumentOutOfRangeException(nameof(tier), $"Tax tier '{tier}' not recognized.");
    }
}