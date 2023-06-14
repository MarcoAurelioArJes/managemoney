using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class LancamentosViewModel
    {
        private List<LancamentoModel> _lancamentos;
        public LancamentosViewModel(List<LancamentoModel> lancamentos) 
        {
            _lancamentos = lancamentos ?? new List<LancamentoModel>();
        }

        public List<LancamentoModel> Itens => _lancamentos;

        public decimal Gastos => Itens
                                .Where(i => i.TipoDeLancamento == TipoDeLancamentoEnum.Despesa)
                                .Sum(c => c.Valor);

        public decimal Ganhos => Itens
                        .Where(i => i.TipoDeLancamento == TipoDeLancamentoEnum.Receita)
                        .Sum(c => c.Valor);

        public decimal Carteira => Ganhos - Gastos;

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
        public string Descricao { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}