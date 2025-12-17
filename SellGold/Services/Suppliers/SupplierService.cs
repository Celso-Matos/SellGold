using Microsoft.Extensions.Options;
using SellGold.Configurations.Suppliers;
using SellGold.Contracts.DTOs.Suppliers.Requests;
using System.Net.Http.Json;
namespace SellGold.Services.Suppliers
{
    public class SupplierService
    {
        private readonly HttpClient _httpClient;
        private readonly SuppliersApiSettings _settings;

        public SupplierService(HttpClient httpClient, IOptions<SuppliersApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);
        }
        
        public async Task<bool> AddSupplierAsync(CreateSupplierRequest supplier)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddSupplier))
                throw new InvalidOperationException("Endpoint AddSupplier não configurado em SupplierApiSettings.");
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddSupplier, supplier);
            if (response.IsSuccessStatusCode)
            {
                return true; // sucesso
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Erro ao adicionar fornecedor: {response.StatusCode} - {error}");
            }
        }
    }
}
