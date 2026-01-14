using MediatR;
using AutoMapper;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Contracts.DTOs.Messaging;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Messaging;
using System.Text.Json;


namespace SellGold.Products.Application.Handlers.Products
{
    public class ProductProduceMessageHandler : IRequestHandler<ProductProduceMessageCommand, Unit>
    {
        private readonly IProductsProducerService _producer;
        private readonly IMapper _mapper;

        public ProductProduceMessageHandler(IProductsProducerService producer, IMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ProductProduceMessageCommand command, CancellationToken cancellationToken)
        {
            // Converte cada ProductRequest em ProductMessage (DTO para Kafka)
            var messages = command.Products
                .Select(request => _mapper.Map<ProductMessage>(request))
                .ToList();

            // Serializa lista de mensagens para JSON
            var jsonMessage = JsonSerializer.Serialize(messages);

            // Envia para Kafka
            await _producer.ProductsProducerAsync(jsonMessage);

            return Unit.Value;
        }
    }
}
