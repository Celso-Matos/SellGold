namespace SellGold.GraphQL.Suppliers.Queries
{
    public static class ListSupplierGraphQLQuery
    {
        public const string GetSuppliers = @"
          query {
              allSuppliersGraphQL {
                supplierId
                corporateName
                tradeName
                cnpj
                stateRegistration
                email
                phone
                isActive
                createdAt
                updatedAt
                addresses {
                  addressId
                  street
                  number
                  complement
                  district
                  city
                  state
                  zipCode
                  country
                }
               }
            }";
    }
}
