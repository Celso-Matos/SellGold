using AutoMapper;
using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Contracts.Mappers
{
    public class ProductProfileMapper : Profile
    {
        public ProductProfileMapper() 
        {
            // Request → Domain
            CreateMap<CreateProductRequest, Product>()
                .ConstructUsing(dto => new Product(
                    dto.Name,
                    dto.Description ?? string.Empty
                ))
                .AfterMap((dto, product) =>
                {
                    var barcode = new ProductBarcode(dto.Barcode, dto.BarcodeType);
                    product.Barcodes.Add(barcode);
                });


            // Domain → Response
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.Barcodes, opt => opt.MapFrom(src => src.Barcodes));

            // Mapear também os tipos internos
            CreateMap<ProductBarcode, ProductBarcodeResponse>();

        }
    }
}
