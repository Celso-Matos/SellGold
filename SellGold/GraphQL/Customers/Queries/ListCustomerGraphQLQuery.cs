namespace SellGold.GraphQL.Customers.Queries
{
    public static class ListCustomerGraphQLQuery
    {
        public const string GetCustomers = @"
        query($cpf: String!) {
            allCustomersGraphQL(cpf: $cpf) {
            customerId
            name
            document
            email
            phone
            isActive
            addresses {
                street
                number
                complement
                district
                city
                state
                zipCode
                country
                type
            }
            createdAt
            updatedAt
                
                }
            }";
    }
}
