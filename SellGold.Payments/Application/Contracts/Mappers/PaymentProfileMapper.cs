using AutoMapper;
using SellGold.Payments.Application.Contracts.DTOs.Requests;
using SellGold.Payments.Application.Contracts.DTOs.Responses;
using SellGold.Payments.Domain.Entities;

namespace SellGold.Payments.Application.Contracts.Mappers
{
    public class PaymentProfileMapper : Profile
    {
        public PaymentProfileMapper()
        {
            // =========================
            // Request → Domain (parcial)
            // =========================
            CreateMap<CreatePaymentRequest, Payment>()
                .ForMember(dest => dest.PaymentId, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMoney, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethod, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CompletedAt, opt => opt.Ignore());

            // =========================
            // Domain → Response
            // =========================
            CreateMap<Payment, PaymentResponse>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.PaymentMoney.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.PaymentMoney.Currency))
                .ForMember(dest => dest.PaymentMethodId, opt => opt.MapFrom(src => src.PaymentMethod.PaymentMethodId))
                .ForMember(dest => dest.PaymentMethodCode, opt => opt.MapFrom(src => src.PaymentMethod.PaymentMethodCode))
                .ForMember(dest => dest.PaymentMethodType, opt => opt.MapFrom(src => src.PaymentMethod.PaymentMethodType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(src => src.Invoice.InvoiceId))
                .ForMember(dest => dest.InvoiceNumber, opt => opt.MapFrom(src => src.Invoice.Number))
                .ForMember(dest => dest.InvoiceAmount, opt => opt.MapFrom(src => src.Invoice.InvoiceMoney.Amount))
                .ForMember(dest => dest.InvoiceCurrency, opt => opt.MapFrom(src => src.Invoice.InvoiceMoney.Currency))
                .ForMember(dest => dest.InvoiceStatus, opt => opt.MapFrom(src => src.Invoice.Status.ToString()));
        }
    }
}