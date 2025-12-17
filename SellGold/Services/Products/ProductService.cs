using Microsoft.Extensions.Options;
using SellGold.Configurations.Products;
using SellGold.Contracts.DTOs.Products.Requests;
using SellGold.Contracts.DTOs.Products.Responses;
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
        public async Task<bool> AddProductAsync(CreateProductRequest product)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddProduct))
                throw new InvalidOperationException("Endpoint AddProduct não configurado em ProductsApiSettings.");
            var payload = new { CreateProductRequest = product };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddProduct, payload);
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
        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync(_settings.Endpoints.GetProducts);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductResponse>>() ?? throw new InvalidOperationException("A resposta da API não trouxe produtos.");            

        }

    }
}
