using managemoney.Models;
using managemoney.Helpers;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class CategoriaRepository : BaseRepository<CategoriaModel>, ICategoriaRepository
    {
        private ContextoDoUsuario _contextoDoUsuario;

        public CategoriaRepository(ApplicationContext applicationContext,
                                   ContextoDoUsuario contextoDoUsuario)
        : base(applicationContext)
        {
            _contextoDoUsuario = contextoDoUsuario;
        }

        public void Criar(CategoriaModel categoria)
        {
            VerificarSeCategoriaExiste(categoria);
            
            categoria.UsuarioID = _contextoDoUsuario.ObterIdDoUsuarioAtual();
            _dbSet.Add(categoria);
            Salvar();
        }

        public void Atualizar(int id, CategoriaModel categoriaNovo)
        {
            VerificarSeCategoriaExiste(categoriaNovo);

            var categoria = ObterPorId(id);

            categoria.Nome = categoriaNovo.Nome;

            _contexto.Entry(categoria).State = EntityState.Modified;
            Salvar();
        }


        public CategoriaModel ObterPorId(int id)
        {
            var categoria = _dbSet.Where(c => c.Id == id && c.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual()).FirstOrDefault();

            if (categoria is null)
                throw new Exception("Categoria não encontrada!!!");
            
            return categoria;
        }

        public List<CategoriaModel> ObterTodos()
        {
            return _dbSet
                        .Where(c => c.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual())
                        .ToList();
        }

        public void Remover(int id)
        {
            var categoria = ObterPorId(id);

            _dbSet.Entry(categoria).State = EntityState.Deleted;
            Salvar();
        }

        public void VerificarSeCategoriaExiste(CategoriaModel categoria)
        {
            var categoriaDb = _dbSet
                .Where(c => c.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual()
                        && c.Nome.ToLower() == categoria.Nome.ToLower()
                        && c.Id != categoria.Id);
            
            if (categoriaDb.Any())
                throw new ArgumentException("Categoria já cadastrada");
        }

        public void VerificarSeCategoriaPertenceAoUsuario(int categoriaId)
        {
            var categoriaDb = _dbSet
                .Where(c => c.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual()
                        && c.Id == categoriaId);
            
            if (!categoriaDb.Any())
                throw new ArgumentException("Categoria não existe");
        }
    }
}