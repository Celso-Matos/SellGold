using Microsoft.Extensions.Options;
using SellGold.Configurations.Customers;
using SellGold.Contracts.DTOs.Customers.Requests;
using System.Net.Http.Json;

namespace SellGold.Services.Customers
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly CustomersApiSettings _settings;
        public CustomerService(HttpClient httpClient, IOptions<CustomersApiSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);

        }
        public async Task<bool> AddCustomerAsync(CreateCustomerRequest Customer, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_settings.Endpoints.AddCustomer))
                throw new InvalidOperationException("Endpoint AddCustomer não configurado em CustomersApiSettings.");
            var payload = new { CreateCustomerRequest = Customer };
            var response = await _httpClient.PostAsJsonAsync(_settings.Endpoints.AddCustomer, payload, cancellationToken);
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
