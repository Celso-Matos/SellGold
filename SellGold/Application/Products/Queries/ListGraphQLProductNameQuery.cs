using MediatR;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.Application.Products.Queries
{
    public class ListGraphQLProductNameQuery : IRequest<List<ProductResponse>?>
    {
        public string? Name { get; }
        public ListGraphQLProductNameQuery(string? name, CancellationToken cancellationToken = default)
        {
            Name = name;
        }
    }
}
