using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using SalesApi;
using SalesApi.Application;
using SalesApi.Application.Contracts.Products;
using SalesApi.Application.Contracts.Sales;
using SalesApi.Application.Products;
using SalesApi.Application.Sales;
using SalesApi.Domain.Products;
using SalesApi.Domain.Sales;
using SalesApi.Infrastructure.Products;
using SalesApi.Infrastructure.Sales;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleDomainService, SaleDomainService>();
builder.Services.AddScoped<ISaleAppService, SaleAppService>();

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase(builder.Configuration.GetValue<string>("MongoDB:Database"));
    return database;
});

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
