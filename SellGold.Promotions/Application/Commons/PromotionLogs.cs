using Microsoft.Extensions.Logging;

namespace SellGold.Promotions.Application.Commons
{
    internal static partial class PromotionLogs
    {
        [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Promoção {PromotionId} não encontrado"
    )]
        public static partial void PromotionNotFound(
        ILogger logger,
        Guid promotionId);
    }
}
