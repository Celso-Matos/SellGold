using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Requests;

namespace SellGold.Products.Application.Commands
{
    public record CreateProductCommand(ProductRequest CreateProductRequest) : IRequest<ProductRequest>;
}
