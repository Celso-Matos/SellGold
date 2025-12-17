using SellGold.Contracts.DTOs.Suppliers.Requests;
using SellGold.PageModels.Suppliers;

namespace SellGold.Mappings.Suppliers
{
    public static class SupplierMapping
    {
       public static CreateSupplierRequest ToRequest(SupplierPageModel model) =>
            new CreateSupplierRequest
            {
                CorporateName = model.CorporateName,
                TradeName = model.TradeName,
                Cnpj = model.Cnpj,
                StateRegistration = model.StateRegistration,
                Email = model.Email,
                Phone = model.Phone,
                IsActive = model.IsActive,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                Street = model.Street,
                Number = model.Number,
                Complement = model.Complement,
                District = model.District,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Country = model.Country

            };
    }
}
