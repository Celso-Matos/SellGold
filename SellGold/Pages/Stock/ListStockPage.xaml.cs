using SellGold.PageModels.Stock;

namespace SellGold.Pages.Stock;

public partial class ListStockPage : ContentPage
{
	private readonly ListStockPageModel _model;
    public ListStockPage(ListStockPageModel model)
	{
		InitializeComponent();
		BindingContext = _model = model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _model.LoadStockAsync();
    }
}