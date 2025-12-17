namespace SellGold.Contracts.DTOs.Prices.Requests
{
    public partial class PricePolicyRequest
    {

        [Newtonsoft.Json.JsonProperty("pricePolicyId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PricePolicyId { get; set; }

        [Newtonsoft.Json.JsonProperty("strategy", Required = Newtonsoft.Json.Required.Always)]
        public int Strategy { get; set; }

        [Newtonsoft.Json.JsonProperty("rules", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Rules { get; set; } = string.Empty;

    }
}
