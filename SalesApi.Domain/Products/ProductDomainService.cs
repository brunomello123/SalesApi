namespace SalesApi.Domain.Products;

public class ProductDomainService: IProductDomainService
{
    public static Product Create(
        Guid id,
        string title,
        string description,
        string category,
        string image,
        decimal price)
    {
        return new Product(
            id: id,
            title: title,
            description: description,
            category: category,
            image: image,
            price: price
        );
    }
}