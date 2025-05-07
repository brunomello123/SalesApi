using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Products;

namespace SalesApi.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(builder =>
        {
            builder.ToTable("products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.ProductName)
                .HasColumnName("product_name")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(p => p.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(p => p.TaxApplied)
                .HasColumnName("tax_applied")
                .HasColumnType("numeric(18,2)")
                .IsRequired();

            builder.Property(p => p.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("numeric(18,2)")
                .IsRequired();
        });
    }
}