namespace SellGold.GraphQL.Customers.Queries
{
    public static class ListCustomerGraphQLQuery
    {
        public const string GetCustomers = @"
        query {
            allCustomersGraphQL {
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
