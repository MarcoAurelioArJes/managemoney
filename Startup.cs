using managemoney.Repositorios;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace managemoney.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection servicos)
        {
            servicos.AddControllers();
            servicos.AddCors();

            var stringDeConexao = OperatingSystem.IsLinux() ? Configuration.GetConnectionString("Default") 
                                                              : Configuration.GetConnectionString("Local");
            servicos.AddDbContext<ApplicationContext>(o => {
                o.UseSqlServer(stringDeConexao);
            });

            servicos.AddScoped<IUsuarioRepository, UsuarioRepository>();
            servicos.AddScoped<ILancamentoRepository, LancamentoRepository>();
            servicos.AddScoped<ICategoriaRepository, CategoriaRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provedorDeServicos)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(opcao => opcao.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            provedorDeServicos.GetService<ApplicationContext>().Database.Migrate();
        }
    }
}