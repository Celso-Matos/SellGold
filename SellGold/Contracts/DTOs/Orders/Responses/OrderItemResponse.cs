using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Contracts.DTOs.Orders.Responses
{
    public class OrderItemResponse
    {
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Quantity { get; set; }

        [Newtonsoft.Json.JsonProperty("unitPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double UnitPrice { get; set; }

        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Total { get; set; }
    }
}
