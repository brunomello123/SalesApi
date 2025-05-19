namespace SalesApi.Domain.Sales;

public class SaleDomainService: ISaleDomainService
{
    public static Sale Create(
        Guid saleId,
        string saleNumber,
        DateTime saleDate,
        Guid customerId,
        Guid branchId,
        bool isCancelled,
        List<SaleProduct> products)
    {
        return new Sale(
            id: saleId,
            saleNumber: saleNumber,
            saleDate: saleDate,
            customerId: customerId,
            branchId: branchId,
            isCancelled: isCancelled,
            products: products
        );
    }
}