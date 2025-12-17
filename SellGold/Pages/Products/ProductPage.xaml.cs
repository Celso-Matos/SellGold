using SellGold.PageModels.Products;

namespace SellGold.Pages.Products;

public partial class ProductPage : ContentPage
{
	public ProductPage(ProductPageModel model)
	{
        InitializeComponent();
        BindingContext = model;
    }
}


