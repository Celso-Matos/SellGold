using System.ComponentModel.DataAnnotations;

namespace SellGold.Customers.Application.Contracts.DTOs.Requests
{
    public class CustomerRequest
    {
        // Required fields
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter até 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Documento é obrigatório.")]
        [StringLength(14, ErrorMessage = "O Documento deve ter até 14 caracteres (CPF/CNPJ).")]
        public string Document { get; set; } = string.Empty;

        // Optional fields
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(150, ErrorMessage = "O E-mail deve ter até 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Telefone inválido.")]
        [StringLength(20, ErrorMessage = "O telefone deve ter até 20 caracteres.")]
        public string Phone { get; set; } = string.Empty;

        // Addresses
        public List<AddressRequest> Addresses { get; set; } = new List<AddressRequest>();

    }
}
