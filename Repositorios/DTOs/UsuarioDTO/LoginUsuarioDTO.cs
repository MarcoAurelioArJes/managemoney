using System.ComponentModel.DataAnnotations;

namespace managemoney.Repositorios.DTOs.UsuarioDTO
{
    public class LoginUsuarioDTO
    {
        //[Required, DataType(DataType.EmailAddress)]
        [Required]
        public string Nome { get; set; }
        [Required, DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}