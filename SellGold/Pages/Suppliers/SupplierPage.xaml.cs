using SellGold.PageModels.Suppliers;

namespace SellGold.Pages.Suppliers;

public partial class SupplierPage : ContentPage
{
	public SupplierPage(SupplierPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }
}