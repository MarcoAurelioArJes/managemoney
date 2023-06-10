using managemoney.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class ApplicationContext : IdentityDbContext<UsuarioModel>
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
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LancamentoModel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<LancamentoModel>()
                        .Property(l => l.Valor)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<LancamentoModel>()
                        .HasOne(m => m.Usuario)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<LancamentoModel>()
                        .Property(c => c.Descricao)
                        .IsRequired(false);

            modelBuilder.Entity<MetasModel>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<MetasModel>()
                        .Property(l => l.Valor)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<MetasModel>()
                        .HasOne(m => m.Usuario)
                        .WithMany()
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MetasModel>()
                .Property(c => c.Descricao)
                .IsRequired(false);
        }
    }
}