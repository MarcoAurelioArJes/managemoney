using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models
{
    public class FornecedorModel : BaseModel
    {
        public int UsuarioID { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public List<CategoriaFornecedorModel> CategoriasFornecedores { get; set; }
    }
}