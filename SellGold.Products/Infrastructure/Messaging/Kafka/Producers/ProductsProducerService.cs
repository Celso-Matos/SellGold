using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using SellGold.Products.Application.Interfaces.Messaging;
using SellGold.Products.Infrastructure.Messaging.Kafka.Config;

namespace SellGold.Products.Infrastructure.Messaging.Kafka.Producers
{
    public class ProductsProducerService : IProductsProducerService
    {
        private readonly IProducer<string, string>? _producer;
        private readonly ILogger<ProductsProducerService> _logger;
        private const string TopicName = TopicNames.LoadProductTopic;

        public ProductsProducerService(IConfiguration configuration, ILogger<ProductsProducerService> logger)
        {
            _logger = logger;

            var bootstrapServers = configuration["Kafka:BootstrapServers"];
            if (string.IsNullOrEmpty(bootstrapServers))
            {
                _logger.LogError("Kafka BootstrapServers não configurado! Verifique o appsettings.json ou variáveis de ambiente.");
                return; // evita crash, mas não inicializa o producer
            }

            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();

            _logger.LogInformation("KafkaProducerService inicializado com BootstrapServers={BootstrapServers}", bootstrapServers);
        }

        public async Task ProductsProducerAsync(string message)
        {
            if (_producer == null)
            {
                _logger.LogWarning("Tentativa de enviar mensagem, mas o Producer não foi inicializado.");
                return;
            }

            var deliveryResult = await _producer.ProduceAsync(TopicName, new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = message
            });

            _logger.LogInformation("Mensagem enviada para {Topic} [Partition: {Partition}, Offset: {Offset}]",
                deliveryResult.Topic, deliveryResult.Partition, deliveryResult.Offset);

            _producer.Flush(TimeSpan.FromSeconds(5));
        }
    }
}