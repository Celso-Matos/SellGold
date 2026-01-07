using SellGold.PageModels.Payments;

namespace SellGold.Page.Payments;

public partial class ListPaymentCpfPage : ContentPage
{
	public ListPaymentCpfPage(ListPaymentCpfPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}