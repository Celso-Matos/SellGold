using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Stock.Infrastructure.Data.Context;
using SellGold.Stock.API.GraphQL.QueryTypes;
using SellGold.Stock.Application.Handlers.Stock;
using SellGold.Stock.Application.Interfaces.Repositories;
using SellGold.Stock.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositório
builder.Services.AddScoped<IStockRepository, SellGoldStockRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldStockContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldStockConnection")));

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreateStockHandler).Assembly
);


// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<StockQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldStock API v1");
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
