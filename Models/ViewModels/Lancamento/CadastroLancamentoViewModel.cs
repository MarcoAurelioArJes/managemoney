using managemoney.Models.Enums;
using managemoney.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class CadastroLancamentoViewModel
    {   
        
        private ICategoriaRepository _categoriaRepository;
        public CadastroLancamentoViewModel() 
        {
            Categorias = new List<CategoriaModel>();

        }
        public CadastroLancamentoViewModel(ICategoriaRepository categoriaRepository)
        : this()
        {
            _categoriaRepository = categoriaRepository;

        }

        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required(AllowEmptyStrings = true), MaxLength(3000)]
        public string Descricao { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }

        public List<CategoriaModel> Categorias { get; set; }
    }
}