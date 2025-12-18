using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SellGold.Promotions.API.GraphQL.QueryTypes;
using SellGold.Promotions.Application.Contracts.Mappers;
using SellGold.Promotions.Application.Handlers.Promotions;
using SellGold.Promotions.Application.Interfaces.Repositories;
using SellGold.Promotions.Infrastructure.Data.Context;
using SellGold.Promotions.Infrastructure.Repositories;
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
builder.Services.AddScoped<IPromotionsRepository, SellGoldPromotionsRepository>();

// DbContext 
builder.Services.AddDbContext<SellGoldPromotionsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SellGoldPromotionsConnection")));

// Adiciona AutoMapper e carrega todos os Profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PromotionProfileMapper>();
});

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreatePromotionHandler).Assembly
);

// Adiciona serviços GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<PromotionQueryType>()
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SellGoldPromotions API v1");
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
