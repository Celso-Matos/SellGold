using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Contracts.DTOs.Orders.Requests
{
    public class CreateOrderRequest
    {
        [Newtonsoft.Json.JsonProperty("customerId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid CustomerId { get; set; }

        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        public System.Collections.Generic.ICollection<CreateOrderItemRequest> Items { get; set; } = new System.Collections.ObjectModel.Collection<CreateOrderItemRequest>();

        [Newtonsoft.Json.JsonProperty("orderDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? OrderDate { get; set; }
    }
}
