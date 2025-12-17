
namespace SellGold.Contracts.DTOs.Stock.Responses
{
    public partial class StockResponse
    {

        [Newtonsoft.Json.JsonProperty("stockProductId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid StockProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("ProductId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("currentQuantity", Required = Newtonsoft.Json.Required.Always)]
        public int CurrentQuantity { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updatedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("stockMovement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StockMovementResponse> StockMovement { get; set; } = new System.Collections.Generic.List<StockMovementResponse>();

        [Newtonsoft.Json.JsonProperty("stockLocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StockLocationResponse> StockLocation { get; set; } = new System.Collections.Generic.List<StockLocationResponse>();

    }
}
