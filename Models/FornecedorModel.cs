using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models
{
    public class FornecedorModel : BaseModel
    {
        public string CpfCnpj { get; set; }
        public string NomeFantasia { get; set; }
        public CategoriaModel Categoria { get; set; }
    }
}