using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CrudWindowsForm.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection servicos)
        {
            servicos.AddControllers();
            servicos.AddCors();
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