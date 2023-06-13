using managemoney.Models.ViewModels.Lancamento;
using ManageMoney.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace managemoney.Models.ViewModels.Usuario
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), MaxLength(11)]
        [CustomValidation(typeof(CustomValidate), "ValidaCpf")]
        public string Cpf { get; set; }

        [CustomValidation(typeof(CustomValidate), "ValidaData")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), MaxLength(100)]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), Compare("Senha", ErrorMessage = "As senhas se diferem")]        
        public string ConfirmaSenha { get; set; }
    }
}