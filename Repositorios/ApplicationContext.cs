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
            
            modelBuilder.Entity<CategoriaModel>().HasKey(c => c.Id);

            modelBuilder.Entity<FornecedorModel>().HasKey(p => p.Id);

            modelBuilder.Entity<CategoriaFornecedorModel>().HasKey(cf => cf.Id);
            //Relacionamento muito para muitos entre Categorias e Fornecedores
            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .HasOne(c => c.Categoria)
                        .WithMany(c => c.CategoriasFornecedores)
                        .HasForeignKey(c => c.CategoriaID);

            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .HasOne(c => c.Fornecedor)
                        .WithMany(c => c.CategoriasFornecedores)
                        .HasForeignKey(c => c.FornecedorID);

            //Relacionamento Lancamento
            modelBuilder.Entity<LancamentoModel>()
                        .HasKey(p => p.Id);
            
            modelBuilder.Entity<LancamentoModel>()
                        .HasOne(u => u.Usuario);
            
            modelBuilder.Entity<LancamentoModel>()
                        .HasOne(c => c.Categoria);

            modelBuilder.Entity<LancamentoModel>()
                        .HasOne(f => f.Fornecedor);
                        
            modelBuilder.Entity<MetasModel>().HasKey(p => p.Id);
            modelBuilder.Entity<MetasModel>().HasOne(p => p.Usuario);
            modelBuilder.Entity<MetasModel>().HasOne(p => p.Categoria);
        }
    }
}