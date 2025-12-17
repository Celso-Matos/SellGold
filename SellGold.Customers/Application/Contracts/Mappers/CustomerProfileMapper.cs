using AutoMapper;
using SellGold.Customers.Application.Contracts.DTOs.Requests;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Domain.Entities;

namespace SellGold.Customers.Application.Contracts.Mappers
{
    public class CustomerProfileMapper : Profile
    {
        public CustomerProfileMapper()
        {
            // Converte DTO -> Entidade
            CreateMap<CustomerRequest, Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.Ignore()) // gerado pelo domínio
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())   // controlado pelo domínio
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // gerado pelo sistema
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore()); // gerado pelo sistema

            CreateMap<AddressRequest, Address>();

            // Converte Entidade -> DTO
            CreateMap<Customer, CustomerRequest>();
            CreateMap<Address, AddressRequest>();

            // Converte Entidade -> DTO (Response)            
            CreateMap<Customer, CustomerResponse>();
            CreateMap<Address, AddressResponse>();
        }
    }
}
