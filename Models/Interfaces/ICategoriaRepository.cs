using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<CategoriaModel>
    {
        void VerificarSeCategoriaExiste(CategoriaModel categoria);
        void VerificarSeCategoriaPertenceAoUsuario(int categoriaId);
    }
}