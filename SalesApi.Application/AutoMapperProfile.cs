using AutoMapper;
using SalesApi.Application.Contracts.Products;
using SalesApi.Application.Contracts.Sales;
using SalesApi.Domain.Products;
using SalesApi.Domain.Sales;

namespace SalesApi.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Sale, SaleDto>()
            .ForMember(dest => dest.TotalAmount,
                opt => opt.MapFrom(src => src.Products.Sum(p => p.Total)));
        CreateMap<SaleProduct, SaleProductDto>();
    }
}