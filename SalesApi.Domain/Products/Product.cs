using SalesApi.Domain.Abstractions;

namespace SalesApi.Domain.Products;

public class Product: BasicEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Image { get; private set; }
    public decimal Price { get; private set; }

    internal Product(
        Guid id,
        string title,
        string description,
        string category,
        string image,
        decimal price
    ): base(id)
    {
        Title = title;
        Description = description;
        Category = category;
        Image = image;
        Price = price;
    }
}