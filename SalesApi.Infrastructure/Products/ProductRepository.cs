using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Exceptions;
using SalesApi.Domain.Products;

namespace SalesApi.Infrastructure.Products;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product> InsertAsync(Product product)
    {
        var entityEntry = await context.Products.AddAsync(product);

        await SaveChangesAsync();
        
        return entityEntry.Entity;
    }

    public async Task<Product> GetAsync(Guid id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        
        if(product is null)
            throw new EntityNotFoundException(nameof(Product), id);

        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task DeleteAsync(Product product)
    {
        context.Products.Remove(product);
        
        await SaveChangesAsync();
    }

    private async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}