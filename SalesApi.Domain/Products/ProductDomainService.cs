namespace SalesApi.Domain.Products;

public class ProductDomainService: IProductDomainService
{
    public async Task<Product> CreateAsync(
        Guid id,
        string title,
        string description,
        string category,
        string image,
        decimal price)
    {
        var product = new Product(
            id: id,
            title: title,
            description: description,
            category: category,
            image: image,
            price: price
        );

        await Task.CompletedTask;

        return product;
    }
}