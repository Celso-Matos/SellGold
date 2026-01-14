using SellGold.PageModels.Prices;

namespace SellGold.Pages.Prices;
public partial class PricePage : ContentPage
{
	private readonly PricePageModel _model;
    public PricePage(PricePageModel model)
	{
		InitializeComponent();
		BindingContext = _model = model;
    }

	private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
	{
        _model.SearchProductsCommand.Execute(e.NewTextValue);
    }
}