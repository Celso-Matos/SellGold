
namespace SellGold.Contracts.DTOs.Stock.Responses
{
    public partial class AddressResponse
    {

        [Newtonsoft.Json.JsonProperty("addressId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AddressId { get; set; }

        [Newtonsoft.Json.JsonProperty("street", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string Street { get; set; }

        [Newtonsoft.Json.JsonProperty("number", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string Number { get; set; }

        [Newtonsoft.Json.JsonProperty("complement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public required string Complement { get; set; }

        [Newtonsoft.Json.JsonProperty("district", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string District { get; set; }

        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string City { get; set; }

        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string State { get; set; }

        [Newtonsoft.Json.JsonProperty("zipCode", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string ZipCode { get; set; }

        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updatedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset UpdatedAt { get; set; }

    }
}
