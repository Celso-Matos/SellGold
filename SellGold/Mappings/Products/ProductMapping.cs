using SellGold.Contracts.DTOs.Products.Requests;
using SellGold.PageModels.Products;

namespace SellGold.Mappings.Products
{
    public static class ProductMapping
    {
        public static CreateProductRequest ToRequest(ProductPageModel model) =>
            new CreateProductRequest
            {
                Name = model.Name,
                Description = model.Description,
                IsActive = model.IsActive,
                Barcode = model.Barcode,
                BarcodeType = model.BarcodeType
            };
    }
}
