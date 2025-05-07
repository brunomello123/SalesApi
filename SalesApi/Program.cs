using Microsoft.EntityFrameworkCore;
using SalesApi.Application.Contracts.Products;
using SalesApi.Application.Products;
using SalesApi.Domain.Products;
using SalesApi.Infrastructure;
using SalesApi.Infrastructure.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();  
builder.Services.AddScoped<IProductAppService, ProductAppService>();  

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SalesApiDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
