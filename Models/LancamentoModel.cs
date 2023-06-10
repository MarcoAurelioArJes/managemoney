using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Lancamentos")]
    public class LancamentoModel : BaseModel
    {
        [Required]
        public string UsuarioID { get; set; }
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required, Range(18,2)]
        public decimal Valor { get; set; }
        [Required(AllowEmptyStrings = true), MaxLength(3000)]
        public string Descricao { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }
        [ForeignKey("CategoriaID")]
        public CategoriaModel Categoria { get; set; }
    }
}