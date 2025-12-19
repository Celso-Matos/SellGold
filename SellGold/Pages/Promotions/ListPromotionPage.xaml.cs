using SellGold.PageModels.Promotions;

namespace SellGold.Pages.Promotions;

public partial class ListPromotionPage : ContentPage
{
	private readonly ListPromotionPageModel _model;
	public ListPromotionPage(ListPromotionPageModel model)
	{
		InitializeComponent();
		BindingContext = _model = model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _model.LoadPromotionsAsync();
    }
}