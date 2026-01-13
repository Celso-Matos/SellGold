using MediatR;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.Application.Products.Queries
{
    public class ListGraphQLProductBarcodeQuery : IRequest<ProductResponse?>
    {
        public string? Barcode { get; }
        public ListGraphQLProductBarcodeQuery(string? barcode, CancellationToken cancellationToken = default)
        {
            Barcode = barcode;
        }
    }
}
