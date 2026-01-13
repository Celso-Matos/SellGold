
namespace SellGold.GraphQL.Payments.Queries
{
    public static class ListPaymentCpfGraphQLQuery
    {
        public const string GetPaymentCpf = @"
        query($cpf: String!) {
            customerGraphQLByCpf(cpf: $cpf) {
                success
                message
                customerId
                name
                document
                email
                phone
                isActive
            }
        }";
    }
}
