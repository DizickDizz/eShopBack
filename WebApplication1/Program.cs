using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using WebApplication1.Entities;
using WebApplication1.Repository;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices(services =>
{
    services
        .AddSingleton<OrdersService>()
        .AddSingleton<IOrderRepository, OrderRepository>()
        .AddSingleton<ICartRepository, CartRepository>()
        .AddSingleton<IProductRepository, ProductRepository>()
        .AddSingleton<CartService>()
        .AddSingleton<ProductService>();
});

FluentMapper.Initialize(config =>
{
    config.ForDommel();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();


