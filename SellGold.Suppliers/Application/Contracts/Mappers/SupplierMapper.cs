using SellGold.Suppliers.Application.Contracts.DTOs.Requests;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Domain.Entities;

namespace SellGold.Suppliers.Application.Contracts.Mappers
{
    public static class SupplierMapper
    {
        // Converte DTO -> Entidade
        public static Supplier ToEntity(SupplierRequest request)
        {
            var _supplierId = Guid.NewGuid();
            return new Supplier
            {
                SupplierId = _supplierId,
                CorporateName = request.CorporateName,
                TradeName = request.TradeName,
                Cnpj = request.Cnpj,
                StateRegistration = request.StateRegistration,
                Email = request.Email,
                Phone = request.Phone,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressId = Guid.NewGuid(),
                        SupplierId = _supplierId,
                        Street = request.Street,
                        Number = request.Number,
                        Complement = request.Complement,
                        District = request.District,
                        City = request.City,
                        State = request.State,
                        ZipCode = request.ZipCode,
                        Country = request.Country,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                }
            };
        }

        // Converte Entidade -> DTO
        public static SupplierRequest ToRequest(Supplier supplier)
        {
            return new SupplierRequest
            {
                CorporateName = supplier.CorporateName,
                TradeName = supplier.TradeName,
                Cnpj = supplier.Cnpj,
                StateRegistration = supplier.StateRegistration,
                Email = supplier.Email,
                Phone = supplier.Phone,
                IsActive = supplier.IsActive,                
                Street = supplier.Addresses.FirstOrDefault()?.Street ?? string.Empty,
                Number = supplier.Addresses.FirstOrDefault()?.Number ?? string.Empty,
                Complement = supplier.Addresses.FirstOrDefault()?.Complement,
                District = supplier.Addresses.FirstOrDefault()?.District ?? string.Empty,
                City = supplier.Addresses.FirstOrDefault()?.City ?? string.Empty,
                State = supplier.Addresses.FirstOrDefault()?.State ?? string.Empty,
                ZipCode = supplier.Addresses.FirstOrDefault()?.ZipCode ?? string.Empty,
                Country = supplier.Addresses.FirstOrDefault()?.Country ?? string.Empty
            };
        }

        // Converte Entidade -> DTO (Response)
        public static SupplierResponse ToResponse(Supplier supplier)
        {
            return new SupplierResponse
            {
                SupplierId = supplier.SupplierId,
                CorporateName = supplier.CorporateName,
                TradeName = supplier.TradeName,
                Cnpj = supplier.Cnpj,
                StateRegistration = supplier.StateRegistration,
                Email = supplier.Email,
                Phone = supplier.Phone,
                IsActive = supplier.IsActive,
                CreatedAt = supplier.CreatedAt,
                UpdatedAt = supplier.UpdatedAt,
                Addresses = supplier.Addresses.Select(a => new AddressResponse 
                {
                    AddressId = a.AddressId,
                    Street = a.Street,
                    Number = a.Number,
                    City = a.City,                    
                    Complement = a.Complement,
                    Country = a.Country,
                    District = a.District,                    
                    State = a.State,                    
                    ZipCode = a.ZipCode

                }).ToList()
            };
        }

        // Converte Lista de Entidades -> Lista de DTOs (Response)
        public static List<SupplierResponse> ToResponseList(IEnumerable<Supplier> suppliers)
        {
            return suppliers.Select(ToResponse).ToList();
        }

    }
}
