using managemoney.Models;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opcoes) 
        : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().HasKey(p => p.Id);

            modelBuilder.Entity<CategoriaModel>().HasKey(p => p.Id);

            modelBuilder.Entity<LancamentoModel>().HasKey(p => p.Id);
            
            modelBuilder.Entity<MetasModel>().HasKey(p => p.Id);
            
            modelBuilder.Entity<FornecedorModel>().HasKey(p => p.Id);
        }
    }
}