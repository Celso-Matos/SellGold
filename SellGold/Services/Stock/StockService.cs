using Microsoft.Extensions.Options;
using SellGold.Configurations.Stock;
using SellGold.Contracts.DTOs.Stock.Requests;
using SellGold.Contracts.DTOs.Stock.Responses;
using System.Net.Http.Json;


namespace SellGold.Services.Stock
{
    public class StockService
    {
        private readonly HttpClient _httpClient;
        private readonly StockApiSettings _settings;
        public StockService(HttpClient httpClient, IOptions<StockApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }
        public async Task<bool> AddStockAsync(CreateStockRequest stock)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddStock))
                throw new InvalidOperationException("Endpoint AddStock não configurado em StockApiSettings.");
            var payload = new { CreateStockRequest = stock };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddStock, payload);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar estoque: {response.StatusCode} - {error}");
            }
        }
        public async Task<IEnumerable<StockResponse>> GetStocksAsync()
        {
            var response = await _httpClient.GetAsync(_settings.Endpoints.GetStock);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<StockResponse>>() ?? throw new InvalidOperationException("A resposta da API não trouxe estoques.");
        }
    }
}
