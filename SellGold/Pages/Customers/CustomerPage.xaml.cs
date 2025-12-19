using SellGold.PageModels.Customers;

namespace SellGold.Pages.Customers;

public partial class CustomerPage : ContentPage
{
    public CustomerPage(CustomerPageModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}