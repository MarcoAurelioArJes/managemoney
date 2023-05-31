using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace managemoney.Models.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        void Criar(T modelo);
        void Atualizar(int id, T novoModelo);
        List<T> ObterTodos();
        T ObterPorId(int id);
        void Remover(int id);
    }
}