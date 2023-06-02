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

            modelBuilder.Entity<UsuarioModel>()
                        .HasKey(p => p.Id);
            
            modelBuilder.Entity<CategoriaModel>()
                        .HasKey(c => c.Id);

            modelBuilder.Entity<CategoriaModel>()
                        .HasOne(m => m.Usuario)
                        .WithOne()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FornecedorModel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<FornecedorModel>()
                        .Property(f => f.CpfCnpj)
                        .IsRequired(false);
            
            modelBuilder.Entity<FornecedorModel>()
                        .HasOne(m => m.Usuario)
                        .WithOne()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .HasKey(cf => cf.Id);

            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .Property(cf => cf.FornecedorID)
                        .IsRequired(false);
            
            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .Property(cf => cf.CategoriaID)
                        .IsRequired(false);

            modelBuilder.Entity<CategoriaFornecedorModel>()
                        .HasOne(m => m.Usuario)
                        .WithOne()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LancamentoModel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<LancamentoModel>()
                        .Property(l => l.Valor)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<LancamentoModel>()
                        .HasOne(m => m.Usuario)
                        .WithOne()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MetasModel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<MetasModel>()
                        .Property(l => l.Valor)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<MetasModel>()
                        .HasOne(m => m.Usuario)
                        .WithOne()
                        .OnDelete(DeleteBehavior.NoAction);
        }
    }
}