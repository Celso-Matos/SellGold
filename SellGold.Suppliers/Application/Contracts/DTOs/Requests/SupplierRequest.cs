using System.ComponentModel.DataAnnotations;


namespace SellGold.Suppliers.Application.Contracts.DTOs.Requests
{
    public class SupplierRequest
    {
        [Required(ErrorMessage = "Razão Social é obrigatório")]
        public required string CorporateName { get; set; }   // Razão Social
        public required string TradeName { get; set; }       // Nome Fantasia

        [Required(ErrorMessage = "Cnpj é obrigatório")]
        public required string Cnpj { get; set; }

        [Required(ErrorMessage = "Inscrição Estadual é obrigatório")]
        public string? StateRegistration { get; set; }
        
        public required string Email { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public required string Phone { get; set; }
        
        public bool IsActive { get; set; } = true;    

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        public required string Number { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public required string District { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório")]
        public required string City { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        public required string State { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public required string ZipCode { get; set; }

        [Required(ErrorMessage = "O Pais é obrigatório")]
        public required string Country { get; set; }
    }
}
