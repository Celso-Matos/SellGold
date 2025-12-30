using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SellGold.Contracts.DTOs.Customers.Requests
{
    public class CreateCustomerRequest
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Document { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Phone { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("addresses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CreateAddressRequest> Addresses { get; set; } = new Collection<CreateAddressRequest>();

    }
}
