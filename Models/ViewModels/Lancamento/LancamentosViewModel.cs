using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class LancamentosViewModel
    {
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
    }
}