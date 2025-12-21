using System.ComponentModel.DataAnnotations;

namespace SellGold.Suppliers.Application.Contracts.DTOs.Requests
{
    public class CreateSupplierRequest
    {
        [Required(ErrorMessage = "Razão Social é obrigatória")]
        public string CorporateName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome Fantasia é obrigatório")]
        public string TradeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        public string Cnpj { get; set; } = string.Empty;

        public string? StateRegistration { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário informar pelo menos um endereço")]
        public List<CreateAddressRequest> Addresses { get; set; } = new();
    }
}
