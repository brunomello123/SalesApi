namespace SalesApi.Domain.Products;

public class ProductDomainService: IProductDomainService
{
    public async Task<Product> CreateAsync(
        Guid id,
        string productName,
        int quantity,
        decimal unitPrice,
        decimal taxApplied,
        decimal totalAmount)
    {
        var product = new Product(
            id: id,
            productName: productName,
            quantity: quantity,
            unitPrice: unitPrice,
            taxApplied: taxApplied,
            totalAmount: totalAmount
        );

        await Task.CompletedTask;

        return product;
    }
}