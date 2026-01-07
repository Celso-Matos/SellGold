namespace SellGold.Contracts.DTOs.Payments.Responses
{
    public partial class PaymentCpfResponse
    {
        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Document { get; } = string.Empty;
    }
}
