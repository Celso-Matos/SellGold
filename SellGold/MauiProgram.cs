using CommunityToolkit.Maui;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SellGold.Application.Customers.Handlers;
using SellGold.Application.Orders.Handlers;
using SellGold.Application.Payments.Handlers;
using SellGold.Application.Prices.Handlers;
using SellGold.Application.Products.Handlers;
using SellGold.Application.Promotions.Handlers;
using SellGold.Application.Stock.Handlers;
using SellGold.Application.Suppliers.Handlers;
using SellGold.Configurations.Customers;
using SellGold.Configurations.Orders;
using SellGold.Configurations.Prices;
using SellGold.Configurations.Products;
using SellGold.Configurations.Promotions;
using SellGold.Configurations.Stock;
using SellGold.Configurations.Suppliers;
using SellGold.Contracts.DTOs.Customers.Requests;
using SellGold.GraphQL.Customers.Services;
using SellGold.GraphQL.Orders.Services;
using SellGold.GraphQL.Payments.Services;
using SellGold.GraphQL.Prices.Services;
using SellGold.GraphQL.Products.Services;
using SellGold.GraphQL.Promotions.Services;
using SellGold.GraphQL.Stock.Services;
using SellGold.GraphQL.Suppliers.Services;
using SellGold.PageModels.Customers;
using SellGold.PageModels.Orders;
using SellGold.PageModels.Payments;
using SellGold.PageModels.Prices;
using SellGold.PageModels.Products;
using SellGold.PageModels.Promotions;
using SellGold.PageModels.Stock;
using SellGold.PageModels.Suppliers;
using SellGold.Pages.Customers;
using SellGold.Pages.Orders;
using SellGold.Pages.Payments;
using SellGold.Pages.Prices;
using SellGold.Pages.Products;
using SellGold.Pages.Promotions;
using SellGold.Pages.Stock;
using SellGold.Pages.Suppliers;
using SellGold.Services.Customers;
using SellGold.Services.Orders;
using SellGold.Services.Payments.Interfaces;
using SellGold.Services.Payments.Readers;
using SellGold.Services.Prices;
using SellGold.Services.Products;
using SellGold.Services.Promotions;
using SellGold.Services.Stock;
using SellGold.Services.Suppliers;
using SellGold.Utils;
using Syncfusion.Maui.Toolkit.Hosting;
using System.Runtime.Versioning;

namespace SellGold;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        try
        {
            var builder = MauiApp.CreateBuilder();

            var aConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Configuration.AddConfiguration(aConfig);

            // Ajusta dinamicamente o BaseUrl
            // Products
            ProductsApiSettings? productsApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                productsApiSettings = aConfig.GetSection("ProductsApiSettingsAndroid").Get<ProductsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                productsApiSettings = aConfig.GetSection("ProductsApiSettingsiOS").Get<ProductsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                productsApiSettings = aConfig.GetSection("ProductsApiSettingsMacOS").Get<ProductsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                productsApiSettings = aConfig.GetSection("ProductsApiSettingsWin").Get<ProductsApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para ProductsApiSettings.");

            if (productsApiSettings == null)
                throw new InvalidOperationException("Configuração ProductsApiSettings não encontrada.");

            builder.Services.Configure<ProductsApiSettings>(options =>
            {
                options.BaseUrl = productsApiSettings.BaseUrl;
                options.Endpoints = productsApiSettings.Endpoints;
            });

            // Suppliers
            SuppliersApiSettings? supplierApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                supplierApiSettings = aConfig.GetSection("SuppliersApiSettingsAndroid").Get<SuppliersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                supplierApiSettings = aConfig.GetSection("SuppliersApiSettingsiOS").Get<SuppliersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                supplierApiSettings = aConfig.GetSection("SuppliersApiSettingsMacOS").Get<SuppliersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                supplierApiSettings = aConfig.GetSection("SuppliersApiSettingsWin").Get<SuppliersApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para SuppliersApiSettings.");

            if (supplierApiSettings == null)
                throw new InvalidOperationException("Configuração SuppliersApiSettings não encontrada.");

            builder.Services.Configure<SuppliersApiSettings>(options =>
            {
                options.BaseUrl = supplierApiSettings.BaseUrl;
                options.Endpoints = supplierApiSettings.Endpoints;
            });

            // Stock
            StockApiSettings? stockApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                stockApiSettings = aConfig.GetSection("StockApiSettingsAndroid").Get<StockApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                stockApiSettings = aConfig.GetSection("StockApiSettingsiOS").Get<StockApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                stockApiSettings = aConfig.GetSection("StockApiSettingsMacOS").Get<StockApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                stockApiSettings = aConfig.GetSection("StockApiSettingsWin").Get<StockApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para StockApiSettings.");

            if (stockApiSettings == null)
                throw new InvalidOperationException("Configuração StockApiSettings não encontrada.");

            builder.Services.Configure<StockApiSettings>(options =>
            {
                options.BaseUrl = stockApiSettings.BaseUrl;
                options.Endpoints = stockApiSettings.Endpoints;
            });

            // Prices
            PricesApiSettings? pricesApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                pricesApiSettings = aConfig.GetSection("PricesApiSettingsAndroid").Get<PricesApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                pricesApiSettings = aConfig.GetSection("PricesApiSettingsiOS").Get<PricesApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                pricesApiSettings = aConfig.GetSection("PricesApiSettingsMacOS").Get<PricesApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                pricesApiSettings = aConfig.GetSection("PricesApiSettingsWin").Get<PricesApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para PricesApiSettings.");

            if (pricesApiSettings == null)
                throw new InvalidOperationException("Configuração PricesApiSettings não encontrada.");

            builder.Services.Configure<PricesApiSettings>(options =>
            {
                options.BaseUrl = pricesApiSettings.BaseUrl;
                options.Endpoints = pricesApiSettings.Endpoints;
            });


            // Promotions
            PromotionsApiSettings? promotionsApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                promotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsAndroid").Get<PromotionsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                promotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsiOS").Get<PromotionsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                promotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsMacOS").Get<PromotionsApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                promotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsWin").Get<PromotionsApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para PromotionsApiSettings.");

            if (promotionsApiSettings == null)
                throw new InvalidOperationException("Configuração PromotionsApiSettings não encontrada.");

            builder.Services.Configure<PromotionsApiSettings>(options =>
            {
                options.BaseUrl = promotionsApiSettings.BaseUrl;
                options.Endpoints = promotionsApiSettings.Endpoints;
            });

            // Orders
            OrdersApiSettings? ordersApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                ordersApiSettings = aConfig.GetSection("OrdersApiSettingsAndroid").Get<OrdersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                ordersApiSettings = aConfig.GetSection("OrdersApiSettingsiOS").Get<OrdersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                ordersApiSettings = aConfig.GetSection("OrdersApiSettingsMacOS").Get<OrdersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                ordersApiSettings = aConfig.GetSection("OrdersApiSettingsWin").Get<OrdersApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para OrdersApiSettings.");

            if (ordersApiSettings == null)
                throw new InvalidOperationException("Configuração OrdersApiSettings não encontrada.");

            builder.Services.Configure<OrdersApiSettings>(options =>
            {
                options.BaseUrl = ordersApiSettings.BaseUrl;
                options.Endpoints = ordersApiSettings.Endpoints;
            });

            // Customers
            CustomersApiSettings? customersApiSettings;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                customersApiSettings = aConfig.GetSection("CustomersApiSettingsAndroid").Get<CustomersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
                customersApiSettings = aConfig.GetSection("CustomersApiSettingsiOS").Get<CustomersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.macOS)
                customersApiSettings = aConfig.GetSection("CustomersApiSettingsMacOS").Get<CustomersApiSettings>();
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                customersApiSettings = aConfig.GetSection("CustomersApiSettingsWin").Get<CustomersApiSettings>();
            else
                throw new InvalidOperationException("Plataforma não suportada para CustomersApiSettings.");

            if (customersApiSettings == null)
                throw new InvalidOperationException("Configuração CustomersApiSettings não encontrada.");

            builder.Services.Configure<CustomersApiSettings>(options =>
            {
                options.BaseUrl = customersApiSettings.BaseUrl;
                options.Endpoints = customersApiSettings.Endpoints;
            });

            //Validation Customers

            CustomersApiSettingsValidation? customersApiSettingsValidation;
            customersApiSettingsValidation = aConfig.GetSection("CustomersApiSettingsValidationCep").Get<CustomersApiSettingsValidation>();

            if (customersApiSettingsValidation == null)
                throw new InvalidOperationException("Configuração CustomersApiSettingsValidation não encontrada.");

            builder.Services.Configure<CustomersApiSettingsValidation>(options =>
            {
                options.BaseUrl = customersApiSettingsValidation.BaseUrl;
            });
                
            // Fim do ajuste dinâmico do BaseUrl

            builder
                .UseMauiApp<App>();
#if WINDOWS || ANDROID || IOS || MACCATALYST
                    builder.UseMauiCommunityToolkit();
#endif
            builder
                .ConfigureSyncfusionToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
                });
            builder.Logging.AddDebug();

            // 🔹 MediatR
            builder.Services.AddMediatR(
                    typeof(CreateProductHandler).Assembly,
                    typeof(ListGraphQLProductsHandler).Assembly,
                    typeof(CreateSupplierHandler).Assembly,
                    typeof(ListGraphQLSuppliersHandler).Assembly,
                    typeof(CreateStockHandler).Assembly,
                    typeof(CreatePriceHandler).Assembly,
                    typeof(CreatePromotionHandler).Assembly,
                    typeof(CreateOrderHandler).Assembly,
                    typeof(CreateCustomerHandler).Assembly,
                    typeof(ListGraphQLCustomersHandler).Assembly,
                    typeof(ListGraphQLPaymentCpfHandler).Assembly
                    );

            // 🔹 Serviços e Repositórios (Singleton)    


            //Services      
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddHttpClient<ProductService>();

            builder.Services.AddScoped<SupplierService>();
            builder.Services.AddHttpClient<SupplierService>();

            builder.Services.AddScoped<StockService>();
            builder.Services.AddHttpClient<StockService>();

            builder.Services.AddScoped<PriceService>();
            builder.Services.AddHttpClient<PriceService>();

            builder.Services.AddScoped<PromotionService>();
            builder.Services.AddHttpClient<PromotionService>();

            builder.Services.AddScoped<OrderService>();
            builder.Services.AddHttpClient<OrderService>();

            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddHttpClient<CustomerService>();


            // 🔹 PageModels principais (Transient)  
            builder.Services.AddTransient<ProductPageModel>();
            builder.Services.AddTransient<ListProductPageModel>();
            builder.Services.AddTransient<ListProductGraphQLService>();

            builder.Services.AddTransient<SupplierPageModel>();
            builder.Services.AddTransient<ListSupplierPageModel>();
            builder.Services.AddTransient<ListSupplierGraphQLService>();

            builder.Services.AddTransient<StockPageModel>();
            builder.Services.AddTransient<ListStockPageModel>();
            builder.Services.AddTransient<ListStockGraphQLService>();

            builder.Services.AddTransient<PricePageModel>();
            builder.Services.AddTransient<ListPricePageModel>();
            builder.Services.AddTransient<ListPriceGraphQLService>();

            builder.Services.AddTransient<PromotionPageModel>();
            builder.Services.AddTransient<ListPromotionPageModel>();
            builder.Services.AddTransient<ListPromotionGraphQLService>();

            builder.Services.AddTransient<OrderPageModel>();
            builder.Services.AddTransient<ListOrderPageModel>();
            builder.Services.AddTransient<ListOrderGraphQLService>();

            builder.Services.AddTransient<CustomerPageModel>();
            builder.Services.AddTransient<ListCustomerPageModel>();
            builder.Services.AddTransient<ListCustomerGraphQLService>();

            builder.Services.AddTransient<ListPaymentCpfGraphQLService>();


            // 🔹 Páginas com Shell Route
            builder.Services.AddTransientWithShellRoute<ProductPage, ProductPageModel>("products");
            builder.Services.AddTransientWithShellRoute<SupplierPage, SupplierPageModel>("suppliers");
            builder.Services.AddTransientWithShellRoute<StockPage, StockPageModel>("stock");
            builder.Services.AddTransientWithShellRoute<PricePage, PricePageModel>("prices");
            builder.Services.AddTransientWithShellRoute<PromotionPage, PromotionPageModel>("promotions");
            builder.Services.AddTransientWithShellRoute<OrderPage, OrderPageModel>("orders");
            builder.Services.AddTransientWithShellRoute<CustomerPage, CustomerPageModel>("customers");
            builder.Services.AddTransientWithShellRoute<PaymentPage, PaymentPageModel>("payments");



            builder.Services.AddTransientWithShellRoute<ListProductPage, ListProductPageModel>("list-products");
            builder.Services.AddTransientWithShellRoute<ListSupplierPage, ListSupplierPageModel>("list-suppliers");
            builder.Services.AddTransientWithShellRoute<ListStockPage, ListStockPageModel>("list-stock");
            builder.Services.AddTransientWithShellRoute<ListPricePage, ListPricePageModel>("list-prices");
            builder.Services.AddTransientWithShellRoute<ListPromotionPage, ListPromotionPageModel>("list-promotions");
            builder.Services.AddTransientWithShellRoute<ListOrderPage, ListOrderPageModel>("list-orders");
            builder.Services.AddTransientWithShellRoute<ListCustomerPage, ListCustomerPageModel>("list-customers");
            builder.Services.AddTransientWithShellRoute<ListPaymentCpfPage, ListPaymentCpfPageModel>("list-payment-cpf");

            // Injeta ApiSettings via IOptions
            builder.Services.Configure<ProductsApiSettings>(builder.Configuration.GetSection("ProductsApiSettings"));
            builder.Services.Configure<SuppliersApiSettings>(builder.Configuration.GetSection("SuppliersApiSettings"));
            builder.Services.Configure<StockApiSettings>(builder.Configuration.GetSection("StockApiSettings"));
            builder.Services.Configure<PricesApiSettings>(builder.Configuration.GetSection("PricesApiSettings"));
            builder.Services.Configure<PromotionsApiSettings>(builder.Configuration.GetSection("PromotionsApiSettings"));
            builder.Services.Configure<OrdersApiSettings>(builder.Configuration.GetSection("OrdersApiSettings"));
            builder.Services.Configure<CustomersApiSettings>(builder.Configuration.GetSection("CustomersApiSettings"));
                        

            // Registra todos os validators automaticamente
            builder.Services.AddValidatorsFromAssemblyContaining<CpfFluentValidation>();
            builder.Services.AddValidatorsFromAssemblyContaining<ContactFluentValidator>();

            // FluentValidation
            builder.Services.AddScoped<IValidator<CreateCustomerRequest>, ContactFluentValidator>();

            // CepService
            builder.Services.AddScoped<CepService>();

            // Payments Reader - Keyboard
            builder.Services.AddSingleton<IBarcodeReader, KeyboardBarcodeReader>();


            return builder.Build();

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("EXCEPTION REAL:");
            System.Diagnostics.Debug.WriteLine(ex.ToString());
            throw;
        }        
    }
}