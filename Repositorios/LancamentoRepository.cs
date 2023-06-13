using AutoMapper;
using managemoney.Helpers;
using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class LancamentoRepository : BaseRepository<LancamentoModel>, ILancamentoRepository
    {
        private ContextoDoUsuario _contextoDoUsuario;
        private ICategoriaRepository _categoriaRepository;

        public LancamentoRepository(ApplicationContext contexto,
                                    ContextoDoUsuario contextoDoUsuario,
                                    ICategoriaRepository categoriaRepository) 
        : base (contexto)
        {
            _contextoDoUsuario = contextoDoUsuario;
            _categoriaRepository = categoriaRepository;
        }

        public void Criar(LancamentoModel lancamento)
        {
            _categoriaRepository.VerificarSeCategoriaPertenceAoUsuario(lancamento.CategoriaID);

            lancamento.UsuarioID = _contextoDoUsuario.ObterIdDoUsuarioAtual();
            _dbSet.Add(lancamento);
            Salvar();
        }

        public void Atualizar(int id, LancamentoModel novoLancamento)
        {
            _categoriaRepository.VerificarSeCategoriaPertenceAoUsuario(novoLancamento.CategoriaID);

            var lancamentoDb = ObterPorId(id);
            
            lancamentoDb.Valor = novoLancamento.Valor;
            lancamentoDb.Descricao = novoLancamento.Descricao;
            lancamentoDb.CategoriaID = novoLancamento.CategoriaID;
            lancamentoDb.DataLancamento = novoLancamento.DataLancamento;
            lancamentoDb.TipoDeLancamento = novoLancamento.TipoDeLancamento;

            _contexto.Entry(lancamentoDb).State = EntityState.Modified;
            Salvar();
        }


        public LancamentoModel ObterPorId(int id)
        {
            var lancamento = _dbSet
                                .Include(c => c.Categoria)
                                .Where(l => l.Id == id
                                && l.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual()).FirstOrDefault();

            if (lancamento is null)
                throw new Exception("Lançamento não encontrado!!!");
                
            return lancamento;
        }

        public List<LancamentoModel> ObterTodos()
        {
            return _dbSet
                    .Include(l => l.Categoria)
                    .Where(c => c.UsuarioID == _contextoDoUsuario.ObterIdDoUsuarioAtual())
                    .ToList();
        }

        public void Remover(int id)
        {
            var lancamento = ObterPorId(id);

            _dbSet.Entry(lancamento).State = EntityState.Deleted;
            Salvar();
        }
    }
}