using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Infrastructure.Data.Context;
using SellGold.Prices.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositório
builder.Services.AddScoped<IPricesRepository, SellGoldPricesRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldPricesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldPricesConnection")));

var app = builder.Build();

// Habilita Swagger apenas em Development
void ConfigureSwaggerUI(SwaggerUIOptions c)
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldPrices API v1");
    c.RoutePrefix = "swagger";
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(ConfigureSwaggerUI);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
