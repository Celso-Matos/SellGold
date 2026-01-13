
namespace SellGold.Services.Payments.Interfaces
{
    /// <summary>
    /// Contrato para leitores de código de barras.
    /// Permite que diferentes implementações (teclado, serial, bluetooth, SDK)
    /// sejam usadas de forma uniforme na aplicação.
    /// </summary>

    public interface IBarcodeReader
    {
        /// <summary>
        /// Evento disparado quando um código é escaneado.
        /// </summary>
        event EventHandler<string> BarcodeScanned;

        /// <summary>
        /// Inicia a escuta do leitor (abre porta, conecta, etc).
        /// </summary>
        void StartListening();

        /// <summary>
        /// Para a escuta do leitor (fecha porta, desconecta, etc).
        /// </summary>
        void StopListening();

        /// <summary>
        /// Nome ou tipo do leitor (para identificação).
        /// </summary>
        string ReaderName { get; }

    }
}
