using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class EnderecoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Numero { get; set; }

        public string? Complemento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Cep { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Bairro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Cidade { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Estado { get; set; }
    }
}
