using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SellGold.Payments.Infrastructure.Persistence.Mongo.Data
{
    public class PaymentLogDocument
    {
        [BsonId]
        public ObjectId PaymentLogDocumentId { get; set; }  
        public Guid PaymentId { get; set; }
        public string Event { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
