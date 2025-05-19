
using Swashbuckle.AspNetCore.Annotations;

namespace SalesApi.Application.Contracts.Sales;

public record SaleProductDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    [Obsolete("ValueMonetaryTaxApplied is obsolete: business logic now uses Discount instead.")]
    [SwaggerSchema(Description = "This property is obsolete and will be removed soon. Use 'Discount' instead.")]
    public decimal ValueMonetaryTaxApplied { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public Guid SaleId { get; set; }
    public bool IsCancelled { get; set; }
}