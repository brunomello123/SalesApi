using AutoMapper;
using SalesApi.Application.Contracts.Products;
using SalesApi.Domain.Products;

namespace SalesApi.Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}