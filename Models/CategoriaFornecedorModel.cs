using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models
{
    public class CategoriaFornecedorModel : BaseModel 
    {
         public int FornecedorID { get; set; }
         public int CategoriaID { get; set; }
         public FornecedorModel Fornecedor { get; set; }
         public CategoriaModel Categoria { get; set; }
    }
}