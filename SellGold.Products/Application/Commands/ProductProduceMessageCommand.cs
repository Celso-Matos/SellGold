using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Requests;

namespace SellGold.Products.Application.Commands
{
   public record ProductProduceMessageCommand(List<CreateProductRequest> Products) : IRequest<Unit>;

}
