using Microsoft.Extensions.Options;
using SellGold.Configurations.Products;
using SellGold.Contracts.DTOs.Products.Requests;
using System.Net.Http.Json;

namespace SellGold.Services.Products
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ProductsApiSettings _settings;
        public ProductService(HttpClient httpClient, IOptions<ProductsApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;            
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);

        }
        public async Task<bool> AddProductAsync(CreateProductRequest product, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddProduct))
                throw new InvalidOperationException("Endpoint AddProduct não configurado em ProductsApiSettings.");
            var payload = new { CreateProductRequest = product };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddProduct, payload, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar produto: {response.StatusCode} - {error}");
            }
        }       

    }
}
