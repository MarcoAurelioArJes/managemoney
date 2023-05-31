using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class UsuarioRepository : BaseRepository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext contexto) 
        : base(contexto) 
        {

        }

        public void Criar(UsuarioModel usuario)
        {
            _dbSet.Add(usuario);
            Salvar();
        }

        public void Atualizar(int id, UsuarioModel novoUsuario)
        {
            var usuario = ObterPorId(id);
            if (usuario is null)
                throw new Exception("Usuário não encontrado!!!");

            usuario.Nome = novoUsuario.Nome;
            usuario.Cpf = novoUsuario.Cpf;
            usuario.Email = novoUsuario.Email;
            usuario.Telefone = novoUsuario.Telefone;

            _contexto.Entry(usuario).State = EntityState.Modified;
            Salvar();
        }

        public UsuarioModel ObterPorId(int id)
        {
            return _dbSet.Where(u => u.Id == id).FirstOrDefault();
        }

        public List<UsuarioModel> ObterTodos()
        {
            return new List<UsuarioModel>();
        }

        public void Remover(int id)
        {

        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}