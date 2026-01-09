
namespace SellGold.Contracts.DTOs.Customers.Responses
{
    public class AddressByCepResponse
    {
        [Newtonsoft.Json.JsonProperty("logradouro", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string logradouro { get; set; } = string.Empty;
        
        [Newtonsoft.Json.JsonProperty("complemento", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string complemento { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("bairro", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string bairro { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("localidade", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string localidade { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("estado", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string estado { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("cep", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string cep { get; set; } = string.Empty;
        
        [Newtonsoft.Json.JsonProperty("erro", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Erro { get; set; } = false;

    }
}
