using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SellGold.Contracts.DTOs.Customers.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public List<CreateAddressRequest> Addresses { get; set; } = new();
    }
}
