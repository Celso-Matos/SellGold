using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Contracts.DTOs.Customers.Responses
{
    public class AddressResponse
    {
        [Newtonsoft.Json.JsonProperty("street", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Street { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("number", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Number { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("complement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Complement { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("district", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string District { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string City { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string State { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("zipCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ZipCode { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Country { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("addressType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddressType { get; set; } = string.Empty;
    }
}
