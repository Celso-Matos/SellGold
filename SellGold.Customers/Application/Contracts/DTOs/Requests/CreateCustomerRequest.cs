using System.ComponentModel.DataAnnotations;

namespace SellGold.Customers.Application.Contracts.DTOs.Requests
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Documento é obrigatório.")]
        public string Document { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public List<CreateAddressRequest> Addresses { get; set; } = new();

    }
}
