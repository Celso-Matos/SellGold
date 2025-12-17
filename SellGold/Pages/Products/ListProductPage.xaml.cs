using SellGold.PageModels.Products;

namespace SellGold.Pages.Products;

public partial class ListProductPage : ContentPage
{
    private readonly ListProductPageModel _model;

    public ListProductPage(ListProductPageModel model)
	{
		InitializeComponent();
        BindingContext = _model = model;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _model.LoadProductsAsync();
    }

}