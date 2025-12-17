using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.Products
{
    public record GetProductByIdQuery(Guid ProductId) : IRequest<ProductResponse>;

}
