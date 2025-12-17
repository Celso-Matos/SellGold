
namespace SellGold.Contracts.DTOs.Stock.Responses
{
    public partial class StockLocationResponse
    {
        [Newtonsoft.Json.JsonProperty("stockLocationId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid StockLocationId { get; set; }

        [Newtonsoft.Json.JsonProperty("stockLocationName", Required = Newtonsoft.Json.Required.AllowNull)]
        public required string StockLocationName { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updatedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("addresses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AddressResponse> Addresses { get; set; } = new System.Collections.ObjectModel.Collection<AddressResponse>();
    }
}
