using Asp.Versioning;
using CartService.Persistence.Contexts;
using CartService.Persistence.Repositories;
using CartService.Domain.Repositories.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;
using CartService.Domain.Interfaces;
using CartService.Application.MessageHandlers;
using CartService.RabbitMQClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using CartService.API.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CartServiceDbOptions>(builder.Configuration.GetSection("CartServiceDbOptions"));
builder.Services.AddSingleton<ICartServiceContext, CartServiceContext>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<CartService.Application.Services.CartService>();
builder.Services.AddTransient<CartService.Application.Services.ItemService>();

builder.Services.AddSingleton<IMessageListenerFactory>(provider =>
    new MessageListenerFactory(
        builder.Configuration.GetSection("MessageQueue").GetValue<string>("Address")));

builder.Services.AddHostedService<ItemUpdateListener>();

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cart API", Version = "1.0" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Cart API", Version = "2.0" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Keycloak:Authority"];
        options.Audience = builder.Configuration["Keycloak:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Keycloak:Authority"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Keycloak:Audience"],
            ValidateLifetime = true,
            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.Name,
            AuthenticationType = JwtBearerDefaults.AuthenticationScheme
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart API V1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "Cart API V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseMiddleware<TokenLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
