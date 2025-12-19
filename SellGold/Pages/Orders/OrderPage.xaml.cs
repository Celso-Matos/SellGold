using SellGold.PageModels.Orders;

namespace SellGold.Pages.Orders;

public partial class OrderPage : ContentPage
{
	public OrderPage(OrderPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}