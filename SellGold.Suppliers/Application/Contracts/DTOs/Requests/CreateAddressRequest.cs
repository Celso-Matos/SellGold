using System.ComponentModel.DataAnnotations;

namespace SellGold.Suppliers.Application.Contracts.DTOs.Requests
{
    public class CreateAddressRequest
    {
        [Required(ErrorMessage = "Rua é obrigatória.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Número é obrigatório.")]
        public string Number { get; set; } = string.Empty;

        public string? Complement { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string District { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Estado é obrigatório.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "País é obrigatório.")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo do endereço é obrigatório.")]
        public string Type { get; set; } = string.Empty;

    }
}
