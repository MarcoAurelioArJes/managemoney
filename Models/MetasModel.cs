using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Metas")]
    public class MetasModel : BaseModel
    {
        [Required]
        public string UsuarioID { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public bool RelacionarMesAnterior { get; set; }
        [Required]
        public bool RelacionarPorCategoria { get; set; }
        [Required, MaxLength(60)]
        public string Titulo { get; set; }
        [Required(AllowEmptyStrings = true), MaxLength(2000)]
        public string Descricao { get; set; }
        [Required, Range(18,2)]
        public decimal Valor { get; set; }
        [Required]
        public bool Finalizada { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }
        [ForeignKey("Categorias")]
        public CategoriaModel Categoria { get; set; }
    }
}