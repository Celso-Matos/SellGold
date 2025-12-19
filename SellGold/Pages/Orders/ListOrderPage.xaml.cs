using SellGold.PageModels.Orders;

namespace SellGold.Pages.Orders;

public partial class ListOrderPage : ContentPage
{
	private readonly ListOrderPageModel _model;
	public ListOrderPage(ListOrderPageModel model)
	{
		InitializeComponent();
		BindingContext = _model = model;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _model.LoadOrdersAsync();
    }
}