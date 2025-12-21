using AutoMapper;
using SellGold.Suppliers.Application.Contracts.DTOs.Requests;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Domain.Entities;
using SellGold.Suppliers.Domain.ValueObjects;

namespace SellGold.Suppliers.Application.Contracts.Mappers
{
    public class SupplierProfileMapper : Profile
    {
        public SupplierProfileMapper()
        {
            // =========================
            // Request → Domain
            // =========================

            CreateMap<CreateSupplierRequest, Supplier>()
                .ConstructUsing(dto => new Supplier(
                    dto.CorporateName,
                    dto.TradeName,
                    dto.Cnpj,
                    dto.Email,
                    dto.Phone,
                    dto.StateRegistration))
                .AfterMap((dto, Supplier) =>
                {
                    foreach (var addressDto in dto.Addresses)
                    {
                        var address = new Address(
                            new StreetInfo(
                                addressDto.Street,
                                addressDto.Number,
                                addressDto.Complement),
                            new Place(
                                addressDto.District,
                                addressDto.City,
                                addressDto.State,
                                addressDto.Country),
                            addressDto.ZipCode,
                            addressDto.Type);

                        Supplier.AddAddress(address);
                    }
                });

            // =========================
            // Domain → Response
            // =========================

            CreateMap<Supplier, SupplierResponse>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src =>
                    src.Addresses.Select(address => new AddressResponse
                    {
                        Street = address.StreetInfo.Street,
                        Number = address.StreetInfo.Number,
                        Complement = address.StreetInfo.Complement,
                        District = address.Location.District,
                        City = address.Location.City,
                        State = address.Location.State,
                        ZipCode = address.ZipCode,
                        Country = address.Location.Country,
                        Type = address.Type
                    })));
        }
    }
}
