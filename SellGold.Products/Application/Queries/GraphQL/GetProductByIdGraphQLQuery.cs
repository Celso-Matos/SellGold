using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.GraphQL
{
    public record GetProductByIdGraphQLQuery(Guid ProductId) : IRequest<ProductResponse>;

}
