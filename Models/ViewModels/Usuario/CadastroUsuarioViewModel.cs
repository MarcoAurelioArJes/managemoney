using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Usuario
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), MaxLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), Compare("Senha")]        
        public string ConfirmaSenha { get; set; }
    }
}