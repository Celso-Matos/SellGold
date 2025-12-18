using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Orders.API.GraphQL.QueryTypes;
using SellGold.Orders.Application.Contracts.Mappers;
using SellGold.Orders.Application.Handlers.Orders;
using SellGold.Orders.Application.Interfaces.Repositories;
using SellGold.Orders.Infrastructure.Data.Context;
using SellGold.Orders.Infrastructure.Repositories;
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
builder.Services.AddScoped<IOrdersRepository, SellGoldOrdersRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldOrdersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldOrdersConnection")));

// Adiciona AutoMapper e carrega todos os Profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<OrderProfileMapper>();
});

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreateOrderHandler).Assembly
);

// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<OrderQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldOrders API v1");
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
