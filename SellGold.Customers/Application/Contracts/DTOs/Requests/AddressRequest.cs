using System.ComponentModel.DataAnnotations;

namespace SellGold.Customers.Application.Contracts.DTOs.Requests
{
    public class AddressRequest
    {
        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        [StringLength(200, ErrorMessage = "O Logradouro deve ter até 200 caracteres.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Número é obrigatório")]
        [StringLength(20, ErrorMessage = "O Número deve ter até 20 caracteres.")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Cidade é obrigatório")]
        [StringLength(100, ErrorMessage = "A Cidade deve ter até 100 caracteres.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O Estado deve ter 2 caracteres (UF).")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(9, ErrorMessage = "O CEP deve ter até 9 caracteres.")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [StringLength(100, ErrorMessage = "O Bairro deve ter até 100 caracteres.")]
        public string District { get; set; } = string.Empty;

        // Optional
        [StringLength(20, ErrorMessage = "O tipo deve ter até 20 caracteres.")]
        public string Type { get; set; } = "Residential";

    }
}
