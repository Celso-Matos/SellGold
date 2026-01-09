using Microsoft.Extensions.Options;
using SellGold.Configurations.Customers;
using SellGold.Contracts.DTOs.Customers.Responses;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SellGold.Services.Customers
{
    public class CepService
    {
        private readonly HttpClient _httpClient;
        private readonly CustomersApiSettingsValidation _settings;

        public CepService(HttpClient httpClient, IOptions<CustomersApiSettingsValidation> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }

        public async Task<AddressByCepResponse> ObterEnderecoPorCepAsync(string cep)
        {
            // Remove caracteres não numéricos
            cep = new string(cep.Where(char.IsDigit).ToArray());

            if (string.IsNullOrWhiteSpace(_settings.BaseUrl))
                throw new InvalidOperationException("Endpoint ViaCepUrl não configurado em CustomersApiSettings.");

            var url = string.Format(_settings.BaseUrl, cep);

            var response = await _httpClient.GetFromJsonAsync<AddressByCepResponse>(url);

            if (response == null || response.Erro)
                throw new HttpRequestException($"CEP inválido ou não encontrado.");


            return response;
        }

    }
}
