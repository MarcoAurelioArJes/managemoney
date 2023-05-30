using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using managemoney.Models.Enums;

namespace managemoney.Models
{
    public class LancamentoModel : BaseModel
    {
        public string Fornecedor { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoDeLancamentoEnum TipoDeLancamento { get; set; }
        public bool Recorrente { get; set; }
        public bool Notificacao { get; set; }
    }
}