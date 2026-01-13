using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;

namespace SellGold.Products.Application.Queries.GraphQL
{
    public class GetProductByBarcodeGraphQLQuery : IRequest<ProductResponse>
    {
        public string Barcode { get; }
        public GetProductByBarcodeGraphQLQuery(string barcode, CancellationToken cancellationToken = default)
        {
            Barcode = barcode;
        }
    }
}
