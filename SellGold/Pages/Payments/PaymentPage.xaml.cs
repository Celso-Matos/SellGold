using SellGold.PageModels.Payments;
using SellGold.Services.Payments.Readers;

namespace SellGold.Pages.Payments;


public partial class PaymentPage : ContentPage
{
    private readonly KeyboardBarcodeReader _keyboardReader;

    public PaymentPage(PaymentPageModel model, KeyboardBarcodeReader reader)
	{
		InitializeComponent();
		BindingContext = model;
		_keyboardReader = reader;
    }

    private void OnBarcodeCompleted(object sender, EventArgs e)
    {
        var codigo = BarcodeEntry.Text;
        if (!string.IsNullOrWhiteSpace(codigo))
        {
            _keyboardReader.RaiseScan(codigo);
            BarcodeEntry.Text = string.Empty; // limpa para próxima leitura
        }
    }

}