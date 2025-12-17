
namespace SellGold.Contracts.DTOs.Prices.Responses
{
    public partial class PriceTaxResponse
    {

        [Newtonsoft.Json.JsonProperty("priceTaxId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PriceTaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.AllowNull)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("rate", Required = Newtonsoft.Json.Required.Always)]
        public double Rate { get; set; }

        [Newtonsoft.Json.JsonProperty("priceId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PriceId { get; set; }

    }
}
