
using System.ComponentModel.DataAnnotations;

namespace SellGold.Contracts.DTOs.Prices.Requests
{
    public partial class CreatePriceRequest
    {

        [Newtonsoft.Json.JsonProperty("priceId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PriceId { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal BasePriceAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("basePriceCurrency", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        public string BasePriceCurrency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("discounts", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<PriceDiscountRequest> Discounts { get; set; } = new System.Collections.ObjectModel.Collection<PriceDiscountRequest>();

        [Newtonsoft.Json.JsonProperty("policies", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<PricePolicyRequest> Policies { get; set; } = new System.Collections.ObjectModel.Collection<PricePolicyRequest>();

        [Newtonsoft.Json.JsonProperty("taxes", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<PriceTaxRequest> Taxes { get; set; } = new System.Collections.ObjectModel.Collection<PriceTaxRequest>();

    }
}
