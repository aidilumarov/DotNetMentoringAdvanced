using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOcelot(builder.Configuration);
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "API Gateway", Version = "v1" });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway v1");
            });

            app.MapWhen(httpContext => httpContext.Request.Path.Value.StartsWith("/catalog"), builder =>
            {
                builder.UseOcelot().Wait();
            });

            app.MapWhen(httpContext => httpContext.Request.Path.Value.StartsWith("/cart"), builder =>
            {
                builder.UseOcelot().Wait();
            });

            app.Run();
        }
    }
}