using AutoMapper;
using SellGold.Customers.Application.Contracts.DTOs.Requests;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Domain.ValueObject;

namespace SellGold.Customers.Application.Contracts.Mappers
{
    public class CustomerProfileMapper : Profile
    {
        public CustomerProfileMapper()
        {
            // =========================
            // Request → Domain
            // =========================

            CreateMap<CreateCustomerRequest, Customer>()
                .ConstructUsing(dto => new Customer(
                    dto.Name,
                    dto.Document,
                    dto.Email,
                    dto.Phone))
                .AfterMap((dto, customer) =>
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

                        customer.AddAddress(address);
                    }
                });

            // =========================
            // Domain → Response
            // =========================

            CreateMap<Customer, CustomerResponse>()
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
