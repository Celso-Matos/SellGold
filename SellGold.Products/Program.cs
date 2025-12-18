using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Products.API.GraphQL.QueryTypes;
using SellGold.Products.Application.Handlers.Products;
using SellGold.Products.Application.Interfaces.Messaging;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Infrastructure.Data.Context;
using SellGold.Products.Infrastructure.Messaging.Kafka.Producers;
using SellGold.Products.Infrastructure.Repositories;
using SellGold.Products.Infrastructure.Messaging.Kafka.Consumers;
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
builder.Services.AddScoped<IProductsRepository, SellGoldProductsRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldProductsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldProductsConnection")));

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreateProductHandler).Assembly
);

// Kafka Producer
builder.Services.AddSingleton<IProductsProducerService, ProductsProducerService>();

// Kafka Consumer
builder.Services.AddSingleton<IConsumer<Ignore, string>>(sp =>
{
    var config = new ConsumerConfig
    {
        BootstrapServers = builder.Configuration["Kafka:BootstrapServers"], // vem do appsettings.json
        GroupId = builder.Configuration["ConsumerGroups:LoadProductConsumerGroup"], // vem do appsettings.json
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false
    };

    return new ConsumerBuilder<Ignore, string>(config).Build();
});

// Kafka Consumer como HostedService
builder.Services.AddHostedService<ProductsConsumerService>();


// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<ProductQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldProducts API v1");
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