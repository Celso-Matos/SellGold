using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using SellGold.Pages.Customers;
using SellGold.Pages.Orders;
using SellGold.Pages.Payments;
using SellGold.Pages.Prices;
using SellGold.Pages.Products;
using SellGold.Pages.Promotions;
using SellGold.Pages.Stock;
using SellGold.Pages.Suppliers;
using Font = Microsoft.Maui.Font;
using MauiApp = Microsoft.Maui.Controls.Application;

namespace SellGold;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		var currentTheme = MauiApp.Current!.RequestedTheme;		
		ThemeSegmentedControl.SelectedIndex = currentTheme == AppTheme.Light ? 0 : 1;
		Routing.RegisterRoute("products",typeof(ProductPage));
		Routing.RegisterRoute("list-products", typeof(ListProductPage));

        Routing.RegisterRoute("suppliers", typeof(SupplierPage));
        Routing.RegisterRoute("list-suppliers", typeof(ListSupplierPage));

        Routing.RegisterRoute("customers", typeof(CustomerPage));
        Routing.RegisterRoute("list-customers", typeof(ListCustomerPage));

        Routing.RegisterRoute("stock", typeof(StockPage));
        Routing.RegisterRoute("list-stock", typeof(ListStockPage));

        Routing.RegisterRoute("prices", typeof(PricePage));
        Routing.RegisterRoute("list-prices", typeof(ListPricePage));

        Routing.RegisterRoute("promotions", typeof(PromotionPage));
        Routing.RegisterRoute("list-promotions", typeof(ListPromotionPage));

        Routing.RegisterRoute("orders", typeof(OrderPage));
        Routing.RegisterRoute("list-orders", typeof(ListOrderPage));

        Routing.RegisterRoute("products", typeof(ProductPage));
        Routing.RegisterRoute("list-products", typeof(ListProductPage));

        
        Routing.RegisterRoute("list-payment-cpf", typeof(ListPaymentCpfPage));
    }
	public static async Task DisplaySnackbarAsync(string message)
	{
		using var cancellationTokenSource = new CancellationTokenSource();

		var snackbarOptions = new SnackbarOptions
		{
			BackgroundColor = Color.FromArgb("#FF3300"),	
			TextColor = Colors.White,
			ActionButtonTextColor = Colors.Yellow,	
			CornerRadius = new CornerRadius(0),
			Font = Font.SystemFontOfSize(18),
			ActionButtonFont = Font.SystemFontOfSize(14)
		};

		var snackbar = Snackbar.Make(message, visualOptions: snackbarOptions);

		await snackbar.Show(cancellationTokenSource.Token);
	}

	public static async Task DisplayToastAsync(string message)
	{
		// Toast is currently not working in MCT on Windows
		if (OperatingSystem.IsWindows())
			return;

		using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
		await Toast.Make(message, textSize: 18).Show(cts.Token);
	}

	private static void SfSegmentedControl_SelectionChanged(object? sender, Syncfusion.Maui.Toolkit.SegmentedControl.SelectionChangedEventArgs e)
    {
        MauiApp.Current!.UserAppTheme = e.NewIndex == 0 ? AppTheme.Light : AppTheme.Dark;
    }
}
