using Microsoft.Extensions.Options;
using SellGold.Configurations.Promotions;
using SellGold.Contracts.DTOs.Promotions.Requests;
using System.Net.Http.Json;

namespace SellGold.Services.Promotions
{
    public class PromotionService
    {
        private readonly HttpClient _httpClient;
        private readonly PromotionsApiSettings _settings;

        public PromotionService(HttpClient httpClient, IOptions<PromotionsApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }

        public async Task<bool> AddPromotionAsync(CreatePromotionRequest promotion)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddPromotion))
                throw new InvalidOperationException("Endpoint AddPromotions não configurado em PromotionsApiSettings.");
            var payload = new { CreatePromotionRequest = promotion };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddPromotion, payload);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar promoção: {response.StatusCode} - {error}");
            }
        }
    }
}
