using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Categorias")]
    public class CategoriaModel : BaseModel
    {
        [Required]
        public string UsuarioID { get; set; }
        [Required, MaxLength(30)]
        public string Nome { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }
    }
}