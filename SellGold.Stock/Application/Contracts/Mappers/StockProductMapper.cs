using SellGold.Stock.Application.Contracts.DTOs.Requests;
using SellGold.Stock.Application.Contracts.DTOs.Responses;
using SellGold.Stock.Domain.Entities;
using System.Linq;

namespace SellGold.Stock.Application.Contracts.Mappers
{
    public static class StockProductMapper
    {
        // Converte DTO -> Entidade
        public static StockProduct ToEntity(StockRequest request)
        {
            var stockProduct = new StockProduct
            {
                StockProductId = Guid.NewGuid(),
                ProductId = request.ProductId,
                CurrentQuantity = request.CurrentQuantity,                
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StockMovement = new List<StockMovement>(),
                StockLocation = new List<StockLocation>()
            };

            stockProduct.StockMovement.Add( new StockMovement
            {
                StockMovementId = Guid.NewGuid(),
                StockProductId = request.StockProductId,
                DateMovement = request.DateMovement,
                AmountMovement = request.AmountMovement,
                MovementType = request.MovementType,
                Observation = request.Observation,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            var _stockLocationId = Guid.NewGuid();

            stockProduct.StockLocation.Add( new StockLocation
            {
                
                StockLocationId = _stockLocationId,
                StockProductId = request.StockProductId,
                StockLocationName =  request.StockLocationName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressId = Guid.NewGuid(),
                        StockLocationId = _stockLocationId,
                        Street = request.Street,
                        Number = request.Number,
                        Complement = request.Complement,
                        District = request.District,
                        City = request.City,
                        State = request.State,
                        ZipCode = request.ZipCode,
                        Country = request.Country,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                }
            });

            return stockProduct;
        }

        // Conerte Entidade -> DTO
        public static StockRequest ToRequest(StockProduct stockProduct)
        {
            var stockMovement = stockProduct.StockMovement.FirstOrDefault();
            var stockLocation = stockProduct.StockLocation.FirstOrDefault();
            var address = stockLocation?.Addresses.FirstOrDefault();

            return new StockRequest
            {
                StockProductId = stockProduct.StockProductId,
                ProductId = stockProduct.ProductId,
                CurrentQuantity = stockProduct.CurrentQuantity,
                DateMovement = stockMovement?.DateMovement ?? DateTime.MinValue,
                AmountMovement = stockMovement?.AmountMovement ?? 0,
                MovementType = stockMovement?.MovementType ?? 0,
                Observation = stockMovement?.Observation,
                StockLocationName = stockLocation?.StockLocationName ?? string.Empty,
                Street = address?.Street ?? string.Empty,
                Number = address?.Number ?? string.Empty,
                Complement = address?.Complement,
                District = address?.District ?? string.Empty,
                City = address?.City ?? string.Empty,
                State = address?.State ?? string.Empty,
                ZipCode = address?.ZipCode ?? string.Empty,
                Country = address?.Country ?? string.Empty
            };
        }

        // Converte Entidade -> DTO (Response)
        public static StockProductResponse ToResponse(StockProduct stockProduct)
        {
            return new StockProductResponse
            {
                StockProductId = stockProduct.StockProductId,
                ProductId = stockProduct.ProductId,
                CurrentQuantity = stockProduct.CurrentQuantity,
                CreatedAt = stockProduct.CreatedAt,
                UpdatedAt = stockProduct.UpdatedAt,
                StockMovement = stockProduct.StockMovement.Select(sm => new StockMovementResponse
                {
                    StockMovementId = sm.StockMovementId,
                    StockProductId = sm.StockProductId,
                    DateMovement = sm.DateMovement,
                    AmountMovement = sm.AmountMovement,
                    MovementType = sm.MovementType,
                    Observation = sm.Observation,
                    CreatedAt = sm.CreatedAt,
                    UpdatedAt = sm.UpdatedAt
                }).ToList(),
                StockLocation = stockProduct.StockLocation.Select(sl => new StockLocationResponse
                {
                    StockLocationId = sl.StockLocationId,
                    StockLocationName = sl.StockLocationName,
                    CreatedAt = sl.CreatedAt,
                    UpdatedAt = sl.UpdatedAt,
                    Addresses = sl.Addresses.Select(a => new AddressResponse
                    {
                        AddressId = a.AddressId,
                        Street = a.Street,
                        Number = a.Number,
                        Complement = a.Complement,
                        District = a.District,
                        City = a.City,
                        State = a.State,
                        ZipCode = a.ZipCode,
                        Country = a.Country,
                        CreatedAt = a.CreatedAt,
                        UpdatedAt = a.UpdatedAt
                    }).ToList()
                }).ToList()
            };
        }

        // Converte Lista de Entidades -> Lista de DTOs (Response)
        public static List<StockProductResponse> ToResponseList(IEnumerable<StockProduct> stockProducts)
        {
            return stockProducts.Select(sp => ToResponse(sp)).ToList();
        }

    }
}
