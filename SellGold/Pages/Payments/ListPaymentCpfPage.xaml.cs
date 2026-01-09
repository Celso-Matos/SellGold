using SellGold.PageModels.Payments;

namespace SellGold.Pages.Payments;

public partial class ListPaymentCpfPage : ContentPage
{
	public ListPaymentCpfPage(ListPaymentCpfPageModel model)
	{
        BindingContext = model;
        InitializeComponent();		
	}
}