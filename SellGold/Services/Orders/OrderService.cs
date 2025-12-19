using Microsoft.Extensions.Options;
using SellGold.Configurations.Orders;
using SellGold.Contracts.DTOs.Orders.Requests;
using System.Net.Http.Json;

namespace SellGold.Services.Orders
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;
        private readonly OrdersApiSettings _settings;

        public OrderService(HttpClient httpClient, IOptions<OrdersApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }

        public async Task<bool> AddOrderAsync(CreateOrderRequest order, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddOrder))
                throw new InvalidOperationException("Endpoint AddOrder não configurado em OrdersApiSettings.");
            var payload = new { CreateOrderRequest = order };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddOrder, payload, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar pedido: {response.StatusCode} - {error}");
            }
        }
    }
}
