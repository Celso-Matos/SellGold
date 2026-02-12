using SellGold.PageModels.Prices;

namespace SellGold.Pages.Prices;
public partial class PricePage : ContentPage
{	
    public PricePage(PricePageModel model)
	{
		InitializeComponent();
		BindingContext = model;
    }

    private static void OnPriceTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            // Remove caracteres não numéricos
            var digitsOnly = new string(e.NewTextValue.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(digitsOnly, out var value))
            {
                // Divide por 100 para ter duas casas decimais
                value /= 100;

                // Formata como moeda brasileira
                entry.Text = string.Format(
                    System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                    "{0:C}", value);

                // Move o cursor para o fim
                entry.CursorPosition = entry.Text.Length;
            }
        }

    }

}