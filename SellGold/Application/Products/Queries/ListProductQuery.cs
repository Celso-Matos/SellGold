using MediatR;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.Application.Products.Queries
{
    public record ListProductQuery() : IRequest<List<ProductResponse>>;
}
