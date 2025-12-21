using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Suppliers.API.GraphQL.QueryTypes;
using SellGold.Suppliers.Application.Handlers.Suppliers;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Application.Queries.GraphQL;
using SellGold.Suppliers.Infrastructure.Data.Context;
using SellGold.Suppliers.Infrastructure.Repositories;
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
builder.Services.AddScoped<ISupplierRepository, SellGoldSuppliersRepository>();


// DbContext 
builder.Services.AddDbContext<SellGoldSuppliersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldSuppliersConnection")));

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreateSuplierHandler).Assembly
);


// Add services to the container.
builder.Services.AddControllers();


// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<SupplierQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldSuppliers API v1");
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
