using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Requests;

namespace SellGold.Products.Application.Commands
{
    public record CreateProductCommand(CreateProductRequest CreateProductRequest) : IRequest<CreateProductRequest>;
}
