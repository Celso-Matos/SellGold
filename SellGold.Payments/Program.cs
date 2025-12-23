using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SellGold.Payments.Application.Interfaces.Repositories;
using SellGold.Payments.Infrastructure.Persistence.SQL.Data.Context;
using SellGold.Payments.Infrastructure.Persistence.SQL.Repositories;
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
builder.Services.AddScoped<IPaymentsRepository, SellGoldPaymentsRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldPaymentsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldPaymentsConnection")));

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


//MongoDB e Redis
var mongoConnection = builder.Configuration.GetConnectionString("MongoDb");
var redisConnection = builder.Configuration.GetConnectionString("Redis");

// ===============================
// MongoDB
// ===============================
builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(mongoConnection));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var databaseName = builder.Configuration["MongoSettings:DatabaseName"];
    return client.GetDatabase(databaseName);
});

// ===============================
// Redis
// ===============================
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnection;
    options.InstanceName = "SellGold:Payments:";
});

// ===============================
// Health Checks
// ===============================
builder.Services.AddHealthChecks()
    .AddMongoDb(
        sp => sp.GetRequiredService<IMongoClient>(),
        name: "mongodb")
    .AddRedis(
        redisConnection ?? string.Empty,
        name: "redis");



var app = builder.Build();

// Cors
app.UseCors("AllowAll");

// Mapeia o endpoint GraphQL
app.MapGraphQL("/graphql");

// Habilita Swagger apenas em Development
void ConfigureSwaggerUI(SwaggerUIOptions c)
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldPayments API v1");
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
