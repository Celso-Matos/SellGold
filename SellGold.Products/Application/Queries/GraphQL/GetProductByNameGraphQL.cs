using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.GraphQL
{
    public class GetProductByNameGraphQL : IRequest<ProductResponse>
    {
        public string Name { get; }
        public GetProductByNameGraphQL(string name, CancellationToken cancellationToken = default)
        {
            Name = name;
        }
    }
}
