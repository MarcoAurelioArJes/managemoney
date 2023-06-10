using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;
using managemoney.Repositorios.DTOs.CategoriaDTO;

namespace managemoney.Repositorios.DTOs.LancamentosDTO
{
    public class LancamentoDTO
    {
        [Required]
        public int CategoriaID { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
    }
}