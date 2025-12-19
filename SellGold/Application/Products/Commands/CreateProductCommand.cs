using MediatR;
using SellGold.Contracts.DTOs.Products.Requests;

namespace SellGold.Application.Products.Commands
{
    public record CreateProductCommand(CreateProductRequest createProductRequest) : IRequest<bool>;
}
