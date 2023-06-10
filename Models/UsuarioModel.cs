using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    public class UsuarioModel : IdentityUser
    {
        public UsuarioModel()
        : base() { }

        [Required, MaxLength(11)]
        public string Cpf { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}