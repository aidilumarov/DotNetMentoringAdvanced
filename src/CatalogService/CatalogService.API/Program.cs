using CatalogService.Application;
using CatalogService.Application.Categories.CreateCategory;
using CatalogService.Domain.Interfaces;
using CatalogService.Persistence.Context;
using CatalogService.Persistence.Repositories;
using CatalogService.RabbitMQClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogServiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging());

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(new MediatRServiceConfiguration().RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));

builder.Services.AddSingleton<IMessagePublisherFactory>(new MessagePublisherFactory(builder.Configuration.GetSection("MessageQueue").GetValue<string>("Address")));

var app = builder.Build();

// Migrate the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<CatalogServiceDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

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
