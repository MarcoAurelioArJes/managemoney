using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models.ViewModels.Usuario
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório."), DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool LembrarSenha { get; set; }
    }
}