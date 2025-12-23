using MongoDB.Driver;
using SellGold.Payments.Infrastructure.Persistence.Mongo.Data;

namespace SellGold.Payments.Infrastructure.Persistence.Mongo.Repositories
{
    public class PaymentLogRepository
    {
        private readonly IMongoCollection<PaymentLogDocument> _collection;

        public PaymentLogRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<PaymentLogDocument>("PaymentLogs");
        }

        public async Task AddAsync(PaymentLogDocument log)
        {
            await _collection.InsertOneAsync(log);
        }
    }
}
