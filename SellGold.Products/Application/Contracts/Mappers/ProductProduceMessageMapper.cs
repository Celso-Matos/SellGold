using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.DTOs.Messaging;


namespace SellGold.Products.Application.Contracts.Mappers
{
    public static class ProductProduceMessageMapper
    {
        public static ProductMessage ToMessage(ProductRequest request)
        {
            return new ProductMessage
            {
                ProductId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Barcodes = new List<ProductBarcodeMessage>
                {
                    new ProductBarcodeMessage
                    {
                        BarcodeId = Guid.NewGuid(),
                        Barcode = request.Barcode,
                        Type = request.BarcodeType
                    }
                }
            };
        }

    }
}
