using CommunityToolkit.Maui;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SellGold.Application.Products.Handlers;
using SellGold.Application.Suppliers.Handlers;
using SellGold.Application.Stock.Handlers;
using SellGold.Application.Prices.Handlers;
using SellGold.Application.Promotions.Handlers;
using SellGold.Application.Orders.Handlers;
using SellGold.Application.Customers.Handlers;
using SellGold.Services.Products;
using SellGold.Services.Suppliers;
using SellGold.Services.Stock;
using SellGold.Services.Prices;
using SellGold.Services.Promotions;
using SellGold.Services.Orders;
using SellGold.Services.Customers;
using SellGold.Configurations.Products;
using SellGold.Configurations.Suppliers;
using SellGold.Configurations.Stock;
using SellGold.Configurations.Prices;
using SellGold.Configurations.Promotions;
using SellGold.Configurations.Orders;
using SellGold.Configurations.Customers;
using SellGold.GraphQL.Products.Services;
using SellGold.GraphQL.Suppliers.Services;
using SellGold.GraphQL.Stock.Services;
using SellGold.GraphQL.Prices.Services;
using SellGold.GraphQL.Promotions.Services;
using SellGold.GraphQL.Orders.Services;
using SellGold.GraphQL.Customers.Services;
using SellGold.PageModels.Products;
using SellGold.PageModels.Suppliers;
using SellGold.PageModels.Stock;
using SellGold.PageModels.Prices;
using SellGold.PageModels.Promotions;
using SellGold.PageModels.Orders;
using SellGold.PageModels.Customers;
using SellGold.Pages.Products;
using SellGold.Pages.Suppliers;
using SellGold.Pages.Stock;
using SellGold.Pages.Prices;
using SellGold.Pages.Promotions;
using SellGold.Pages.Orders;
using SellGold.Pages.Customers;
using Syncfusion.Maui.Toolkit.Hosting;
using System.Runtime.Versioning;

namespace SellGold;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
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
        StockApiSettings? StockApiSettings;

        if (DeviceInfo.Platform == DevicePlatform.Android)
            StockApiSettings = aConfig.GetSection("StockApiSettingsAndroid").Get<StockApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
            StockApiSettings = aConfig.GetSection("StockApiSettingsiOS").Get<StockApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
            StockApiSettings = aConfig.GetSection("StockApiSettingsMacOS").Get<StockApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            StockApiSettings = aConfig.GetSection("StockApiSettingsWin").Get<StockApiSettings>();
        else
            throw new InvalidOperationException("Plataforma não suportada para StockApiSettings.");

        if (StockApiSettings == null)
            throw new InvalidOperationException("Configuração StockApiSettings não encontrada.");

        builder.Services.Configure<StockApiSettings>(options =>
        {
            options.BaseUrl = StockApiSettings.BaseUrl;
            options.Endpoints = StockApiSettings.Endpoints;
        });

        // Prices
        PricesApiSettings? PricesApiSettings;

        if (DeviceInfo.Platform == DevicePlatform.Android)
            PricesApiSettings = aConfig.GetSection("PricesApiSettingsAndroid").Get<PricesApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
            PricesApiSettings = aConfig.GetSection("PricesApiSettingsiOS").Get<PricesApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
            PricesApiSettings = aConfig.GetSection("PricesApiSettingsMacOS").Get<PricesApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            PricesApiSettings = aConfig.GetSection("PricesApiSettingsWin").Get<PricesApiSettings>();
        else
            throw new InvalidOperationException("Plataforma não suportada para PricesApiSettings.");

        if (PricesApiSettings == null)
            throw new InvalidOperationException("Configuração PricesApiSettings não encontrada.");


        // Promotions
        PromotionsApiSettings? PromotionsApiSettings;

        if (DeviceInfo.Platform == DevicePlatform.Android)
            PromotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsAndroid").Get<PromotionsApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
            PromotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsiOS").Get<PromotionsApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
            PromotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsMacOS").Get<PromotionsApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            PromotionsApiSettings = aConfig.GetSection("PromotionsApiSettingsWin").Get<PromotionsApiSettings>();
        else
            throw new InvalidOperationException("Plataforma não suportada para PromotionsApiSettings.");

        if (PromotionsApiSettings == null)
            throw new InvalidOperationException("Configuração PromotionsApiSettings não encontrada.");

        // Orders
        OrdersApiSettings? OrdersApiSettings;

        if (DeviceInfo.Platform == DevicePlatform.Android)
            OrdersApiSettings = aConfig.GetSection("OrdersApiSettingsAndroid").Get<OrdersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
            OrdersApiSettings = aConfig.GetSection("OrdersApiSettingsiOS").Get<OrdersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
            OrdersApiSettings = aConfig.GetSection("OrdersApiSettingsMacOS").Get<OrdersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            OrdersApiSettings = aConfig.GetSection("OrdersApiSettingsWin").Get<OrdersApiSettings>();
        else
            throw new InvalidOperationException("Plataforma não suportada para OrdersApiSettings.");

        if (OrdersApiSettings == null)
            throw new InvalidOperationException("Configuração OrdersApiSettings não encontrada.");

        // Customers
        CustomersApiSettings? CustomersApiSettings;

        if (DeviceInfo.Platform == DevicePlatform.Android)
            CustomersApiSettings = aConfig.GetSection("CustomersApiSettingsAndroid").Get<CustomersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
            CustomersApiSettings = aConfig.GetSection("CustomersApiSettingsiOS").Get<CustomersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.macOS)
            CustomersApiSettings = aConfig.GetSection("CustomersApiSettingsMacOS").Get<CustomersApiSettings>();
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            CustomersApiSettings = aConfig.GetSection("CustomersApiSettingsWin").Get<CustomersApiSettings>();
        else
            throw new InvalidOperationException("Plataforma não suportada para CustomersApiSettings.");

        if (CustomersApiSettings == null)
            throw new InvalidOperationException("Configuração CustomersApiSettings não encontrada.");

        builder.Services.Configure<PricesApiSettings>(options =>
        {
            options.BaseUrl = PricesApiSettings.BaseUrl;
            options.Endpoints = PricesApiSettings.Endpoints;
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
                typeof(CreateSupplierHandler).Assembly,
                typeof(CreateStockHandler).Assembly,
                typeof(CreatePriceHandler).Assembly,
                typeof(CreatePromotionHandler).Assembly,
                typeof(CreateOrderHandler).Assembly,
                typeof(CreateCustomerHandler).Assembly
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


        // 🔹 Páginas com Shell Route
        builder.Services.AddTransientWithShellRoute<ProductPage, ProductPageModel>("products");
        builder.Services.AddTransientWithShellRoute<SupplierPage, SupplierPageModel>("suppliers");
        builder.Services.AddTransientWithShellRoute<StockPage, StockPageModel>("stock");
        builder.Services.AddTransientWithShellRoute<PricePage, PricePageModel>("prices");
        builder.Services.AddTransientWithShellRoute<PromotionPage, PromotionPageModel>("promotions");
        builder.Services.AddTransientWithShellRoute<OrderPage, OrderPageModel>("orders");
        builder.Services.AddTransientWithShellRoute<CustomerPage, CustomerPageModel>("customers");


        builder.Services.AddTransientWithShellRoute<ListProductPage, ListProductPageModel>(nameof(ListProductPage));
        builder.Services.AddTransientWithShellRoute<ListSupplierPage, ListSupplierPageModel>(nameof(ListSupplierPage));
        builder.Services.AddTransientWithShellRoute<ListStockPage, ListStockPageModel>(nameof(ListStockPage));
        builder.Services.AddTransientWithShellRoute<ListPricePage, ListPricePageModel>(nameof(ListPricePage));
        builder.Services.AddTransientWithShellRoute<ListPromotionPage, ListPromotionPageModel>(nameof(ListPromotionPage));
        builder.Services.AddTransientWithShellRoute<ListOrderPage, ListOrderPageModel>(nameof(ListOrderPage));
        builder.Services.AddTransientWithShellRoute<ListCustomerPage, ListCustomerPageModel>(nameof(ListCustomerPage));

        // Injeta ApiSettings via IOptions
        builder.Services.Configure<ProductsApiSettings>(builder.Configuration.GetSection("ProductsApiSettings"));
        builder.Services.Configure<SuppliersApiSettings>(builder.Configuration.GetSection("SuppliersApiSettings"));
        builder.Services.Configure<StockApiSettings>(builder.Configuration.GetSection("StockApiSettings"));
        builder.Services.Configure<PricesApiSettings>(builder.Configuration.GetSection("PricesApiSettings"));
        builder.Services.Configure<PromotionsApiSettings>(builder.Configuration.GetSection("PromotionsApiSettings"));
        builder.Services.Configure<OrdersApiSettings>(builder.Configuration.GetSection("OrdersApiSettings"));
        builder.Services.Configure<CustomersApiSettings>(builder.Configuration.GetSection("CustomersApiSettings"));

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });        


        return builder.Build();
    }
}