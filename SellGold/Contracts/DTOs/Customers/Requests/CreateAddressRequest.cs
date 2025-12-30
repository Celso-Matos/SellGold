using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Contracts.DTOs.Customers.Requests
{
    public class CreateAddressRequest
    {
        [Newtonsoft.Json.JsonProperty("street", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Street { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("number", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Number { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("complement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Complement { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("district", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string District { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string City { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string State { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("zipCode", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string ZipCode { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Country { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Type { get; set; } = string.Empty;
    }
}
