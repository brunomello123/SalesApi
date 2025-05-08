namespace SalesApi.Domain.Sales;

public class SaleDomainService: ISaleDomainService
{
    public async Task<Sale> CreateAsync(
        Guid saleId,
        string saleNumber,
        DateTime saleDate,
        string customer,
        decimal totalSaleAmount,
        string branch,
        bool isCancelled,
        IEnumerable<SaleProduct> products)
    {
        var sale = new Sale(
            id: saleId,
            saleNumber: saleNumber,
            saleDate: saleDate,
            customer: customer,
            totalSaleAmount: totalSaleAmount,
            branch: branch,
            isCancelled: isCancelled,
            products: products
        );

        await Task.CompletedTask;

        return sale;
    }
}