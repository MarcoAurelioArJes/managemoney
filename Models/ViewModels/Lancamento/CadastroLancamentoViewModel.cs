using managemoney.Models.Enums;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class CadastroLancamentoViewModel
    {   
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

        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
    }
}