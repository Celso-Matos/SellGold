using MediatR;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.Application.Products.Queries
{
    public record ListGraphQLProductsQuery() : IRequest<List<ProductResponse>>;
}
