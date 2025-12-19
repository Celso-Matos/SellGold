using SellGold.Contracts.DTOs.Customers.Requests;
using SellGold.PageModels.Customers;

namespace SellGold.Mappings.Customers
{
    public static class CustomerMapping
    {
        public static CreateCustomerRequest ToRequest(CustomerPageModel model) =>
            new CreateCustomerRequest
            {
                Name = model.Name,
                Document = model.Document,
                Email = model.Email,
                Phone = model.Phone,
                Addresses = model.Addresses?.ToList() ?? new List<CreateAddressRequest>()
            };
    }
}
