using SellGold.PageModels.Prices;

namespace SellGold.Pages.Prices;
public partial class ListPricePage : ContentPage
{
	private readonly ListPricePageModel _model;
    public ListPricePage(ListPricePageModel model)
	{
		InitializeComponent();
		BindingContext = _model = model;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _model.LoadPricesAsync();
    }
}