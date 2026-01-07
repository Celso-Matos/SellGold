using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using MediatR;
using SellGold.Application.Payments.Queries;
using SellGold.Contracts.DTOs.Payments.Requests;
using SellGold.Contracts.DTOs.Payments.Responses;
using SellGold.Mappings.Payments;
using SellGold.Utils;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Payments;

public partial class ListPaymentCpfPageModel : ObservableObject
{
    private readonly IMediator _mediator;
    private readonly IValidator<PaymentCpfRequest> _validator;


    private CustomerResponse _Customers = new();
    public CustomerResponse Customers
    {
        get => _Customers;
        set => SetProperty(ref _Customers, value);
    }

    public string Document { get; set; } = string.Empty;

    private string? _errorMessage;
    public string? ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(); }
    }

    // Command de Ação
    public IAsyncRelayCommand FindCommand { get; }

    public ListPaymentCpfPageModel(IMediator mediator, IValidator<PaymentCpfRequest> validator)
    {
        _mediator = mediator;
        _validator = validator;
        FindCommand = new AsyncRelayCommand(ValidateCpfAsync);
    }

    public async Task ValidateCpfAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var validaCpfRequest = PaymentCpfMapping.ToRequest(this);

            var result = _validator.Validate(validaCpfRequest);

            if (!result.IsValid)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException(result.Errors[0].ErrorMessage);
            }

            var customers = await _mediator.Send(
                new ListGraphQLPaymentCpfQuery(validaCpfRequest.CPF, cancellationToken)
            );

            Customers = customers;


        }
        catch (System.ComponentModel.DataAnnotations.ValidationException ex)
        {
            ErrorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Unexpected error: {ex.Message}";
        }
    }


}