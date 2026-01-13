using SellGold.Services.Payments.Interfaces;

namespace SellGold.Services.Payments.Readers
{
    public class KeyboardBarcodeReader : IBarcodeReader
    {
        public event EventHandler<string>? BarcodeScanned;
        public string ReaderName => "Keyboard Reader";

        public void StartListening()
        {
            // No modo teclado, não há configuração extra.
            // O Entry da tela já captura o texto.
        }

        public void StopListening()
        {
            // Nada a fazer no modo teclado.
        }

        // Método auxiliar para disparar evento manualmente
        public void RaiseScan(string codigo)
        {
            BarcodeScanned?.Invoke(this, codigo);
        }

    }
}
