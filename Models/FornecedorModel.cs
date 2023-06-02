using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace managemoney.Models
{
    [Table("Fornecedores")]
    public class FornecedorModel : BaseModel
    {
        [Required]
        public int UsuarioID { get; set; }
        [Required, MaxLength(100)]
        public string NomeFantasia { get; set; }
        [Required(AllowEmptyStrings = true), MaxLength(14)]
        public string CpfCnpj { get; set; }

        [ForeignKey("UsuarioID")]
        public UsuarioModel Usuario { get; set; }
        public List<CategoriaFornecedorModel> CategoriasFornecedores { get; set; }
    }
}