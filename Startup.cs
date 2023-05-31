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

            servicos.AddDbContext<ApplicationContext>(o => {
                o.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            servicos.AddScoped<IUsuarioRepository, UsuarioRepository>();
            servicos.AddScoped<ILancamentoRepository, LancamentoRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
        }
    }
}