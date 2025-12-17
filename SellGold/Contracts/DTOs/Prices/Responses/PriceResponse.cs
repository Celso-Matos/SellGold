
namespace SellGold.Contracts.DTOs.Prices.Responses
{
    public partial class PriceResponse
    {

        [Newtonsoft.Json.JsonProperty("priceId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PriceId { get; set; }

        [Newtonsoft.Json.JsonProperty("basePriceAmount", Required = Newtonsoft.Json.Required.Always)]
        public double BasePriceAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("basePriceCurrency", Required = Newtonsoft.Json.Required.AllowNull)]
        public string BasePriceCurrency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("discounts", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Collections.Generic.ICollection<PriceDiscountResponse> Discounts { get; set; }

        [Newtonsoft.Json.JsonProperty("policies", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Collections.Generic.ICollection<PricePolicyResponse> Policies { get; set; }

        [Newtonsoft.Json.JsonProperty("taxes", Required = Newtonsoft.Json.Required.AllowNull)]
        public System.Collections.Generic.ICollection<PriceTaxResponse> Taxes { get; set; }

        [Newtonsoft.Json.JsonProperty("isActive", Required = Newtonsoft.Json.Required.Always)]
        public bool IsActive { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? UpdatedAt { get; set; }

    }
}
