using System.ComponentModel.DataAnnotations;

namespace SellGold.Customers.Application.Contracts.DTOs.Requests
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Documento é obrigatório.")]
        public string Document { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public List<CreateAddressRequest> Addresses { get; set; } = new();

    }
}
