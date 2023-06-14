using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class DetalhesViewModel
    {
        public DetalhesViewModel() 
        {

        }

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
        public string Descricao { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}