using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Contracts.Mappers
{
    public static class ProductMapper
    {
        // Converte DTO -> Entidade
        public static Product ToEntity(ProductRequest request)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                IsActive = request.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Barcode = new List<ProductBarcode>()
            };

            product.Barcode.Add(new ProductBarcode
            {
                BarcodeId = Guid.NewGuid(),
                Barcode = request.Barcode,
                Type = request.BarcodeType
            });

            return product;
        }

        // Converte Entidade -> DTO
        public static ProductRequest ToRequest(Product product)
        {
            return new ProductRequest
            {
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
                Barcode = product.Barcode.FirstOrDefault()?.Barcode ?? string.Empty,
                BarcodeType = product.Barcode.FirstOrDefault()?.Type ?? string.Empty
            };
        }

        // Converte Entidade -> DTO (Response)
        public static ProductResponse ToResponse(Product product)
        {
            return new ProductResponse
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                Barcodes = product.Barcode.Select(b => new ProductBarcodeResponse
                {
                    BarcodeId = b.BarcodeId,
                    Barcode = b.Barcode,
                    Type = b.Type
                }).ToList()
            };
        }

        // Converte Lista de Entidades -> Lista de DTOs (Response)
        public static List<ProductResponse> ToResponseList(IEnumerable<Product> products)
        {
            return products.Select(ToResponse).ToList();
        }


    }
}