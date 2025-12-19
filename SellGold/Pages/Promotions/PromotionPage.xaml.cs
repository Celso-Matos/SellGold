using SellGold.PageModels.Promotions;

namespace SellGold.Pages.Promotions;

public partial class PromotionPage : ContentPage
{
	public PromotionPage(PromotionPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}