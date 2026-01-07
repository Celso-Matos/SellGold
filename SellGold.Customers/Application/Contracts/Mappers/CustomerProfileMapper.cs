using AutoMapper;
using SellGold.Customers.Application.Contracts.DTOs.Requests;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Domain.ValueObjects;

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
                .ForMember(dest => dest.Addresses, opt => opt.Ignore()) // evita erro de coleção read-only
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
                            addressDto.AddressType);

                        customer.AddAddress(address);
                    }
                });

            // =========================
            // Domain → Response
            // =========================
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            // =========================
            // Domain Address → Response Address
            // =========================
            CreateMap<Address, AddressResponse>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.StreetInfo.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.StreetInfo.Number))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.StreetInfo.Complement))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.Place.District))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Place.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Place.State))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Place.Country))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.AddressType, opt => opt.MapFrom(src => src.AddressType));
        }
    }
}