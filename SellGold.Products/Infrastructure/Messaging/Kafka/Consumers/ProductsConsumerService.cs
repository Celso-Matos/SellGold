using Confluent.Kafka;
using MediatR;
using Newtonsoft.Json;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Infrastructure.Messaging.Kafka.Config;


namespace SellGoldProducts.Infrastructure.Messaging.Kafka.Consumers
{
    public class ProductsConsumerService : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ProductsConsumerService> _logger;
        private const string TopicName = TopicNames.LoadProductTopic;

        public ProductsConsumerService(
            IConsumer<Ignore, string> consumer,
            IServiceScopeFactory scopeFactory,
            ILogger<ProductsConsumerService> logger)
        {
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _logger.LogInformation("[KafkaConsumer] Consumidor injetado via DI.");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(TopicName);
            _logger.LogInformation("Consumidor Kafka inscrito no tópico {Topic}", TopicName);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(stoppingToken);
                        if (consumeResult?.Message?.Value != null)
                        {
                            await ProcessMessageAsync(consumeResult, stoppingToken);
                        }
                    }
                    catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (KafkaException ex) when (ex.Error.IsFatal)
                    {
                        _logger.LogError(ex, "Erro fatal no consumidor Kafka.");
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro inesperado no consumidor.");
                        await Task.Delay(2000, stoppingToken);
                    }
                }
            }
            finally
            {
                _consumer.Close();
                _consumer.Dispose();
                _logger.LogInformation("Consumidor Kafka encerrado e recursos liberados.");
            }
        }

        private async Task ProcessMessageAsync(ConsumeResult<Ignore, string> consumeResult, CancellationToken stoppingToken)
        {
            if (consumeResult?.Message?.Value == null)
                return;

            var productDtos = JsonConvert.DeserializeObject<List<ProductRequest>>(consumeResult.Message.Value);
            if (productDtos == null || !productDtos.Any())
                return;

            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new ProductProduceMessageCommand(productDtos);
            await mediator.Send(command, stoppingToken);

            try
            {
                _consumer.Commit(consumeResult);
                _logger.LogInformation("Offset commitado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Falha ao commitar offset.");
            }

            _logger.LogInformation("Lote de {Count} produtos importado e salvo.", productDtos.Count);
        }
    }
}