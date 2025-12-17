using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.GraphQL
{
    public record GetAllProductsGraphQLQuery() : IRequest<List<ProductResponse>>;
    
}
