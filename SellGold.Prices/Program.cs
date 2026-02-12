using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Prices.API.GraphQL.QueryTypes;
using SellGold.Prices.Application.Contracts.Mappers;
using SellGold.Prices.Application.Handlers.GraphQL;
using SellGold.Prices.Application.Handlers.Prices;
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

// Adiciona AutoMapper e carrega todos os Profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PriceProductsProfileMapper>();
});

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreatePriceHandler).Assembly,
    typeof(GetPriceProductsByIdGraphQLHandler).Assembly,
    typeof(GetPriceByIdGraphQLHandler).Assembly
);

// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<PriceQueryType>()
    .AddFiltering()
    .AddSorting();

// Config Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Cors
app.UseCors("AllowAll");

// Mapeia o endpoint GraphQL
app.MapGraphQL("/graphql");

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
