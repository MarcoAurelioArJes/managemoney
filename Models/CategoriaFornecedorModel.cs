using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("CategoriaFornecedor")]
    public class CategoriaFornecedorModel : BaseModel 
    {
        [Required]
        public int UsuarioID { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int? FornecedorID { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int? CategoriaID { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }        
        [ForeignKey("FornecedorID")]
        public FornecedorModel Fornecedor { get; set; }
        [ForeignKey("CategoriaID")]
        public CategoriaModel Categoria { get; set; }
    }
}