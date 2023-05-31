using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class CategoriaRepository : BaseRepository<CategoriaModel>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext applicationContext)
        : base(applicationContext)
        {
            
        }

        public void Criar(CategoriaModel categoria)
        {
            _dbSet.Add(categoria);
            Salvar();
        }

        public void Atualizar(int id, CategoriaModel categoriaNovo)
        {
            var categoria = ObterPorId(id);
            
            if (categoria is null)
                throw new Exception("Lançamento não encontrado!!!");

            categoria.Nome = categoriaNovo.Nome;

            _contexto.Entry(categoria).State = EntityState.Modified;
            Salvar();
        }


        public CategoriaModel ObterPorId(int id)
        {
            return _dbSet.Where(l => l.Id == id).FirstOrDefault();
        }

        public List<CategoriaModel> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Remover(int id)
        {
            var lancamento = ObterPorId(id);

            if (lancamento is null)
                throw new Exception("Categoria não encontrada!!!");

            _dbSet.Entry(lancamento).State = EntityState.Deleted;
            Salvar();
        }
    }
}