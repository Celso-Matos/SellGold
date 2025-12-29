namespace SellGold.Payments.Application.Commons
{
    internal static partial class PaymentLogs
    {
        [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Pagamento {PaymentId} não encontrado"
    )]
        public static partial void PaymentNotFound(
        ILogger logger,
        Guid paymentId);
    }
}
