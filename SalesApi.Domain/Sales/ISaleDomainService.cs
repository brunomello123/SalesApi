namespace SalesApi.Domain.Sales;

public interface ISaleDomainService
{
    Task<Sale> CreateAsync(
        Guid saleId,
        string saleNumber,
        DateTime saleDate,
        string customer,
        decimal totalSaleAmount,
        string branch,
        bool isCancelled,
        IEnumerable<SaleProduct> products
    );
}