using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Contracts.DTOs.Orders.Requests
{
    public class CreateOrderItemRequest
    {
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(1, 2147483647)]
        public int Quantity { get; set; }

        [Newtonsoft.Json.JsonProperty("unitPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Range(0D, 79228162514264337593543950335D)]
        public double UnitPrice { get; set; }
    }
}
