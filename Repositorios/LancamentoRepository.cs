using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class LancamentoRepository : BaseRepository<LancamentoModel>, ILancamentoRepository
    {
        public LancamentoRepository(ApplicationContext contexto) 
        : base (contexto)
        {

        }

        public void Criar(LancamentoModel lancamento)
        {
            _dbSet.Add(lancamento);
            Salvar();
        }

        public void Atualizar(int id, LancamentoModel novoLancamento)
        {
            var lancamento = ObterPorId(id);
            
            if (lancamento is null)
                throw new Exception("Lançamento não encontrado!!!");

            lancamento.Fornecedor = novoLancamento.Fornecedor;
            lancamento.Valor = novoLancamento.Valor;
            lancamento.DataLancamento = novoLancamento.DataLancamento;
            lancamento.TipoDeLancamento = novoLancamento.TipoDeLancamento;
            lancamento.Recorrente = novoLancamento.Recorrente;
            lancamento.Notificacao = novoLancamento.Notificacao;

            _contexto.Entry(lancamento).State = EntityState.Modified;
            Salvar();
        }


        public LancamentoModel ObterPorId(int id)
        {
            return _dbSet.Where(l => l.Id == id).FirstOrDefault();
        }

        public List<LancamentoModel> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Remover(int id)
        {
            var lancamento = ObterPorId(id);

            if (lancamento is null)
                throw new Exception("Lançamento não encontrado!!!");

            _dbSet.Entry(lancamento).State = EntityState.Deleted;
            Salvar();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}