using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Usuarios")]
    public class UsuarioModel : BaseModel
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; }
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