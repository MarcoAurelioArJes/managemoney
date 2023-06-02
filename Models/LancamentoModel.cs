using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Lancamentos")]
    public class LancamentoModel : BaseModel
    {
        [Required]
        public int UsuarioID { get; set; }
        [Required]
        public int CategoriaFornecedorID { get; set; }
        [Required, Range(18,2)]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
        [Required]
        public bool Recorrente { get; set; }
        [Required]
        public bool Notificacao { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }
        [ForeignKey("CategoriaFornecedorID")]
        public CategoriaFornecedorModel CategoriaFornecedor { get; set; }   
    }
}