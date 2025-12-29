using MediatR;
using Microsoft.EntityFrameworkCore;
using SellGold.Payments.Application.Contracts.Mappers;
using SellGold.Payments.Application.Handlers.Payments;
using SellGold.Payments.Application.Interfaces.Repositories;
using SellGold.Payments.Infrastructure.Data.Context;
using SellGold.Payments.Infrastructure.Repositories;
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

// Adiciona AutoMapper e carrega todos os Profiles
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PaymentProfileMapper>();
});

// MediatR Handlers
builder.Services.AddMediatR(
    typeof(CreatePaymentHandler).Assembly
);

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
