using Microsoft.Extensions.Logging;

namespace SellGold.Orders.Application.Commons
{
    internal static partial class OrderLogs
    {
        [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Pedido {OrderId} não encontrado"
    )]
        public static partial void OrderNotFound(
        ILogger logger,
        Guid orderId);
    }
}
