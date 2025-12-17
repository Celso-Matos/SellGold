using Microsoft.Extensions.Options;
using SellGold.Configurations.Prices;
using SellGold.Contracts.DTOs.Prices.Requests;
using SellGold.Contracts.DTOs.Prices.Responses;
using System.Net.Http.Json;
using System.Numerics;

namespace SellGold.Services.Prices
{
    public class PriceService
    {
        private readonly HttpClient _httpClient;
        private readonly PricesApiSettings _settings;

        public PriceService(HttpClient httpClient, IOptions<PricesApiSettings> options) 
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);

        }

        public async Task<bool> AddPriceAsync(CreatePriceRequest price)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddPrice))
                throw new InvalidOperationException("Endpoint AddPrice não configurado em PriceApiSettings.");
            var payload = new { CreatePriceRequest = price };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddPrice, payload);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar preço: {response.StatusCode} - {error}");
            }
        }

        public async Task<IEnumerable<PriceResponse>> GetPricesAsync() 
        {
            var response = await _httpClient.GetAsync(_settings.Endpoints.GetPrices);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<PriceResponse>>() ?? throw new InvalidOperationException("A resposta da API não trouxe preços.");
        }
    }
}
