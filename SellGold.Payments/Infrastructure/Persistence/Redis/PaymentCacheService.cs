using StackExchange.Redis;
using System.Text.Json;

namespace SellGold.Payments.Infrastructure.Persistence.Redis
{
    public class PaymentCacheService
    {
        private readonly IDatabase _database;

        public PaymentCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task SetAsync(string key, object value, TimeSpan expiration)
        {
            var json = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, json, expiration);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.HasValue
                ? JsonSerializer.Deserialize<T>((string)value!)
                : default;
        }
    }
}
