using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models
{
    public class CategoriaModel : BaseModel
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public List<CategoriaFornecedorModel> CategoriasFornecedores { get; set; }
    }
}