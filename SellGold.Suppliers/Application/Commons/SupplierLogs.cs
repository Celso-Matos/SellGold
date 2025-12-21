using Microsoft.Extensions.Logging;

namespace SellGold.Suppliers.Application.Commons
{
    internal static partial class SupplierLogs
    {
        [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Pedido {SupplierId} não encontrado"
    )]
        public static partial void SupplierNotFound(
        ILogger logger,
        Guid supplierId);
    }
}
