
namespace SellGold.Contracts.DTOs.Stock.Responses
{
    public partial class StockMovementResponse
    {

        [Newtonsoft.Json.JsonProperty("stockMovementId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid StockMovementId { get; set; }

        [Newtonsoft.Json.JsonProperty("stockProductId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid StockProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("dateMovement", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.DateTimeOffset DateMovement { get; set; }

        [Newtonsoft.Json.JsonProperty("amountMovement", Required = Newtonsoft.Json.Required.Always)]
        public int AmountMovement { get; set; }

        [Newtonsoft.Json.JsonProperty("movementType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MovementType { get; set; }

        [Newtonsoft.Json.JsonProperty("observation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Observation { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updatedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset UpdatedAt { get; set; }

    }
}
