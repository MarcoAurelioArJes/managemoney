using managemoney.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace managemoney.Repositorios.DTOs.LancamentosDTO
{
    public class CriarLancamentoDTO
    {
        [Required]
        public int CategoriaFornecedorID { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
        [Required]
        public bool Recorrente { get; set; }
        [Required]
        public bool Notificacao { get; set; }
    }
}