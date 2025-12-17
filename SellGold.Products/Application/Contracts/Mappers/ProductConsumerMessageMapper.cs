using SellGold.Products.Application.Contracts.DTOs.Messaging;
using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Contracts.Mappers
{
    public static class ProductConsumerMessageMapper
    {
        public static Product ToEntity(ProductMessage message)
        {
            var product = new Product
            {
                ProductId = message.ProductId,
                Name = message.Name,
                Description = message.Description,
                IsActive = message.IsActive,
                CreatedAt = message.CreatedAt,
                UpdatedAt = message.UpdatedAt,
                Barcode = new List<ProductBarcode>()
            };

            foreach (var barcode in message.Barcodes)
            {
                product.Barcode.Add(new ProductBarcode
                {
                    BarcodeId = barcode.BarcodeId,
                    Barcode = barcode.Barcode,
                    Type = barcode.Type,
                    Product = product
                });
            }

            return product;
        }
    }
}
