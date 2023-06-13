using managemoney.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class CadastroLancamentoViewModel
    {   
        [Required(ErrorMessage = "Informe a categoria")]
        public int? CategoriaID { get; set; }
        
        [Required(ErrorMessage = "Informe a data do lançamento")]
        [CustomValidation(typeof(CadastroLancamentoViewModel), "ValidaData")]
        public DateTime? DataLancamento { get; set; }
        
        [Required(ErrorMessage = "Informe o valor do lançamento")]
        [CustomValidation(typeof(CadastroLancamentoViewModel), "ValidaValor")]
        public decimal? Valor { get; set; }

        [MaxLength(3000, ErrorMessage = "Descrição deve ter no máx. 3000 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Informe o tipo de lançamento")]
        public TipoDeLancamentoEnum? TipoDeLancamento { get; set; }

        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
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


        public static ValidationResult ValidaData(DateTime data, ValidationContext context)
        {
            return (data == DateTime.MinValue)
                ? new ValidationResult("Informe uma data válida!")
                : ValidationResult.Success;
        }

        public static ValidationResult ValidaValor(decimal valor, ValidationContext context)
        {
            return (valor == decimal.Zero)
                ? new ValidationResult("Informe um valor maior que zero!")
                : ValidationResult.Success;
        }
    }
}