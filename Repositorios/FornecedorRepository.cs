using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class FornecedorRepository : BaseRepository<FornecedorModel>, IFornecedorRepository
    {
        public FornecedorRepository(ApplicationContext applicationContext)
        : base(applicationContext)
        {
            
        }

        public void Criar(FornecedorModel fornecedor)
        {
            _dbSet.Add(fornecedor);
            Salvar();
        }

        public void Atualizar(int id, FornecedorModel novoFornecedor)
        {
            var fornecedor = ObterPorId(id);
            
            if (fornecedor is null)
                throw new Exception("Lançamento não encontrado!!!");

            fornecedor.NomeFantasia = novoFornecedor.NomeFantasia;
            fornecedor.CpfCnpj = novoFornecedor.CpfCnpj;
            
            _contexto.Entry(fornecedor).State = EntityState.Modified;
            Salvar();
        }


        public FornecedorModel ObterPorId(int id)
        {
            return _dbSet.Where(l => l.Id == id).FirstOrDefault();
        }

        public List<FornecedorModel> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public void Remover(int id)
        {
            var lancamento = ObterPorId(id);

            if (lancamento is null)
                throw new Exception("Fornecedor não encontrado!!!");

            _dbSet.Entry(lancamento).State = EntityState.Deleted;
            Salvar();
        }
    }
}