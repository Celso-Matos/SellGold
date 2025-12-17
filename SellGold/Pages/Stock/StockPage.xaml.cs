using SellGold.PageModels.Stock;

namespace SellGold.Pages.Stock;
public partial class StockPage : ContentPage
{
	public StockPage(StockPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}