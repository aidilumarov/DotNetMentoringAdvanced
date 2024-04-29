using CartService.Persistence.Contexts;
using CartService.Persistence.Repositories;
using CartService.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CartServiceDbOptions>(builder.Configuration.GetSection("CartServiceDbOptions"));
builder.Services.AddSingleton<ICartServiceContext, CartServiceContext>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
