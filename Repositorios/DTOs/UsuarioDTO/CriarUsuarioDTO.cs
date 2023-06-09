using System.ComponentModel.DataAnnotations;

namespace managemoney.Repositorios.DTOs.UsuarioDTO
{
    public class CriarUsuarioDTO
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
        [Required, Compare("Senha")]        
        public string ConfirmaSenha { get; set; }
    }
}