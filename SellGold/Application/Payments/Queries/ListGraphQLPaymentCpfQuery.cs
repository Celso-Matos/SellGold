using MediatR;
using SellGold.Contracts.DTOs.Payments.Responses;

namespace SellGold.Application.Payments.Queries
{
    public class ListGraphQLPaymentCpfQuery : IRequest<CustomerResponse>
    {
        public string? Document { get; }

        public ListGraphQLPaymentCpfQuery(string? document = null, CancellationToken cancellationToken = default)
        {
            Document = document;
        }
    }
}
