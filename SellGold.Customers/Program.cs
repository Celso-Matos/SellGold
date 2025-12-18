using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Customers.API.GraphQL.QueryTypes;
using SellGold.Customers.Application.Contracts.Mappers;
using SellGold.Customers.Application.Handlers.Customers;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Infrastructure.Data.Context;
using SellGold.Customers.Infrastructure.Repositories;
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
builder.Services.AddScoped<ICustomersRepository, SellGoldCustomersRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldCustomersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldCustomersConnection")));

// Adiciona AutoMapper e carrega todos os Profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CustomerProfileMapper>();
});

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreateCustomerHandler).Assembly
);

// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<CustomerQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldCustomers API v1");
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
