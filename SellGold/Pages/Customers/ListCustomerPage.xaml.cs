using SellGold.PageModels.Customers;

namespace SellGold.Pages.Customers;

public partial class ListCustomerPage : ContentPage
{
    private readonly ListCustomerPageModel _model;
    public ListCustomerPage(ListCustomerPageModel model)
    {
        InitializeComponent();
        BindingContext = _model = model;
    }    
}