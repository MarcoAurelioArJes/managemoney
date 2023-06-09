using AutoMapper;
using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class LancamentoRepository : BaseRepository<LancamentoModel>, ILancamentoRepository
    {
        private IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LancamentoRepository(ApplicationContext contexto,
                                    IMapper mapper, 
                                    IHttpContextAccessor httpContextAccessor) 
        : base (contexto)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string ObterIdDoUsuarioAtual()
        {
            var contexto = _httpContextAccessor.HttpContext;
            return contexto.User.Claims.FirstOrDefault(c => c.Type == "id").Value;
        }

        public void Criar(LancamentoModel lancamento)
        {
            lancamento.UsuarioID =  ObterIdDoUsuarioAtual();
            _dbSet.Add(lancamento);
            Salvar();
        }

        public void Atualizar(int id, LancamentoModel novoLancamento)
        {
            var lancamento = ObterPorId(id);
            
            if (lancamento is null)
                throw new Exception("Lançamento não encontrado!!!");

            _mapper.Map(novoLancamento, lancamento);
            
            _contexto.Entry(lancamento).State = EntityState.Modified;
            Salvar();
        }


        public LancamentoModel ObterPorId(int id)
        {
            return _dbSet.Where(l => l.Id == id).FirstOrDefault();
        }

        public List<LancamentoModel> ObterTodos()
        {
            return _dbSet
                    .ToList();
        }

        public void Remover(int id)
        {
            var lancamento = ObterPorId(id);

            if (lancamento is null)
                throw new Exception("Lançamento não encontrado!!!");

            _dbSet.Entry(lancamento).State = EntityState.Deleted;
            Salvar();
        }
    }
}