using SellGold.PageModels.Prices;

namespace SellGold.Pages.Prices;
public partial class PricePage : ContentPage
{
	public PricePage(PricePageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}