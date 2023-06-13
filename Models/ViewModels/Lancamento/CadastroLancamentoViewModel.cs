using managemoney.Models.Enums;
using ManageMoney.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class CadastroLancamentoViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Informe a categoria")]
        public int? CategoriaID { get; set; }
        
        [Required(ErrorMessage = "Informe a data do lançamento")]
        [CustomValidation(typeof(CustomValidate), "ValidaData")]
        public DateTime? DataLancamento { get; set; }
        
        [Required(ErrorMessage = "Informe o valor do lançamento")]
        [CustomValidation(typeof(CustomValidate), "ValidaValor")]
        public decimal? Valor { get; set; }

        [MaxLength(3000, ErrorMessage = "Descrição deve ter no máx. 3000 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Informe o tipo de lançamento")]
        public TipoDeLancamentoEnum? TipoDeLancamento { get; set; }

        public HashSet<SelectListItem> Categorias { get; set; } = new HashSet<SelectListItem>();
        public List<SelectListItem> TiposDeLancamentos => new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = ((int)TipoDeLancamentoEnum.Receita).ToString(),
                Text = TipoDeLancamentoEnum.Receita.ToString()
            },
            new SelectListItem
            {
                Value = ((int)TipoDeLancamentoEnum.Despesa).ToString(),
                Text = TipoDeLancamentoEnum.Despesa.ToString()
            },
        };
    }
}