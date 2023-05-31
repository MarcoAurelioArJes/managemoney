using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext _contexto;
        protected readonly DbSet<T> _dbSet;
        
        public BaseRepository(ApplicationContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<T>();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}