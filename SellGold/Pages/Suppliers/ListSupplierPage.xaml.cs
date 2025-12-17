using SellGold.PageModels.Products;
using SellGold.PageModels.Suppliers;

namespace SellGold.Pages.Suppliers;

public partial class ListSupplierPage : ContentPage
{
    private readonly ListSupplierPageModel _model;
    public ListSupplierPage(ListSupplierPageModel model)
	{
		InitializeComponent();
        BindingContext = _model = model;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _model.LoadSuppliersAsync();
    }
}