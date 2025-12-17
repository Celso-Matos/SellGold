using MediatR;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Messaging;
using System.Text.Json;


namespace SellGold.Products.Application.Handlers.Products
{
    public class ProductProduceMessageHandler : IRequestHandler<ProductProduceMessageCommand, Unit>
    {
        private readonly IProductsProducerService _producer;

        public ProductProduceMessageHandler(IProductsProducerService producer)
        {
            _producer = producer;
        }

        public async Task<Unit> Handle(ProductProduceMessageCommand command, CancellationToken cancellationToken)
        {
            // Converte cada ProductRequest em ProductMessage (DTO para Kafka)
            var messages = command.Products
                .Select(ProductProduceMessageMapper.ToMessage)
                .ToList();

            // Serializa lista de mensagens para JSON
            var jsonMessage = JsonSerializer.Serialize(messages);

            // Envia para Kafka
            await _producer.ProductsProducerAsync(jsonMessage);

            return Unit.Value;
        }
    }
}
