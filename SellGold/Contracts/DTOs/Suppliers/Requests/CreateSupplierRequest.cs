using System.ComponentModel.DataAnnotations;

namespace SellGold.Contracts.DTOs.Suppliers.Requests
{
    public class CreateSupplierRequest
    {
        [Required(ErrorMessage = "Razão Social é obrigatório")]
        public required string CorporateName { get; set; }   // Razão Social

        [Required(ErrorMessage = "Nome Fantasia é obrigatório")]
        public required string TradeName { get; set; }       // Nome Fantasia

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "Inscrição Estadual é obrigatório")]
        public string? StateRegistration { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public required string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        public required string Number { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public required string District { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public required string City { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório")]
        public required string State { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        public required string ZipCode { get; set; }

        [Required(ErrorMessage = "País é obrigatório")]
        public required string Country { get; set; }
    }
}
