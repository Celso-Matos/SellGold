using Microsoft.Extensions.Logging;

namespace SellGold.Orders.Application.Commons
{
    internal static partial class CustomerLogs
    {
        [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Pedido {CustomerId} não encontrado"
    )]
        public static partial void CustomerNotFound(
        ILogger logger,
        Guid customerId);
    }
}
