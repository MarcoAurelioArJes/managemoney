using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models
{
    public class MetasModel : BaseModel
    {
        public bool RelacionarMesAnterior { get; set; }
        public bool RelacionarPorCategoria { get; set; }
        public CategoriaModel Categoria { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}