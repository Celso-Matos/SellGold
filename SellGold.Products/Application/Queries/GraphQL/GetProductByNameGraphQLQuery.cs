using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.GraphQL
{
    public class GetProductByNameGraphQLQuery : IRequest<List<ProductResponse>?>
    {
        public string? Name { get; }
        public GetProductByNameGraphQLQuery(string? name, CancellationToken cancellationToken = default)
        {
            Name = name;
        }
    }
}
