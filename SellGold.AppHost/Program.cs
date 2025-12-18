using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// -----------------------------
// SQL Server - Produtos
// -----------------------------
var sqlProducts = builder.AddSqlServer("sqlserver-products")
    .WithDataVolume()
    .AddDatabase("SellGoldProducts");

// -----------------------------
// SQL Server - Fornecedores
// -----------------------------
var sqlSuppliers = builder.AddSqlServer("sqlserver-suppliers")
    .WithDataVolume()
    .AddDatabase("SellGoldSuppliers");

// -----------------------------
// SQL Server - Stock
// -----------------------------
var sqlStock = builder.AddSqlServer("sqlserver-stock")
    .WithDataVolume()
    .AddDatabase("SellGoldStock");

// -----------------------------
// SQL Server - Prices
// -----------------------------
var sqlPrices = builder.AddSqlServer("sqlserver-prices")
    .WithDataVolume()
    .AddDatabase("SellGoldPrices");

// -----------------------------
// SQL Server - Customers
// -----------------------------
var sqlCustomers = builder.AddSqlServer("sqlserver-customers")
    .WithDataVolume()
    .AddDatabase("SellGoldCustomers");

// -----------------------------
// SQL Server - Orders
// -----------------------------
var sqlOrders = builder.AddSqlServer("sqlserver-orders")
    .WithDataVolume()
    .AddDatabase("SellGoldOrders");

// -----------------------------
// SQL Server - Promotions
// -----------------------------
var sqlPromotions = builder.AddSqlServer("sqlserver-promotions")
    .WithDataVolume()
    .AddDatabase("SellGoldPromotions");


// -----------------------------
// API de Produtos
// -----------------------------
builder.AddProject<Projects.SellGold_Products>("sellgold-api-products")
    .WithReference(sqlProducts)
    .WithEndpoint("http", e => { e.Port = 11000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 11001; })  // HTTPS
    .WithEnvironment("Kafka__BootstrapServers", "localhost:9093");

// -----------------------------
// API de Suppliers
// -----------------------------
builder.AddProject<Projects.SellGold_Suppliers>("sellgold-api-suppliers")
    .WithReference(sqlSuppliers)
    .WithEndpoint("http", e => { e.Port = 3000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 3001; });   // HTTPS

// -----------------------------
// API de Stock
// -----------------------------
builder.AddProject<Projects.SellGold_Stock>("sellgold-api-stock")
    .WithReference(sqlStock)
    .WithEndpoint("http", e => { e.Port = 1000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 1001; });   // HTTPS

// -----------------------------
// API de Prices
// -----------------------------
builder.AddProject<Projects.SellGold_Prices>("sellgold-api-prices")
    .WithReference(sqlPrices)
    .WithEndpoint("http", e => { e.Port = 9000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 9001; });   // HTTPS

// -----------------------------
// API de Customers
// -----------------------------
builder.AddProject<Projects.SellGold_Customers>("sellgold-api-customers")
    .WithReference(sqlCustomers)
    .WithEndpoint("http", e => { e.Port = 5000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 5001; });   // HTTPS

// -----------------------------
// API de Orders
// -----------------------------
builder.AddProject<Projects.SellGold_Orders>("sellgold-api-orders")
    .WithReference(sqlOrders)
    .WithEndpoint("http", e => { e.Port = 13000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 13001; });   // HTTPS

// -----------------------------
// API de Promotions
// -----------------------------
builder.AddProject<Projects.SellGold_Promotions>("sellgold-api-promotions")
    .WithReference(sqlPromotions)
    .WithEndpoint("http", e => { e.Port = 7000; })   // HTTP
    .WithEndpoint("https", e => { e.Port = 7001; });   // HTTPS


// -----------------------------
// Build & Run
// -----------------------------

await builder.Build().RunAsync();