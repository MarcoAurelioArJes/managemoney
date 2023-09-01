using managemoney.Models;
using managemoney.Helpers;
using managemoney.Repositorios;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Lancamento;
using managemoney.Filters;

var builder = WebApplication.CreateBuilder(args);

var stringDeConexao = OperatingSystem.IsLinux() ? builder.Configuration.GetConnectionString("Default") 
                                                    : builder.Configuration.GetConnectionString("Local");

builder.Services.AddDbContext<ApplicationContext>(o => {
    o.UseSqlServer(stringDeConexao);
});

builder
    .Services
    .AddIdentity<UsuarioModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorization();

builder.Services.AddScoped<ContextoDoUsuario>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<CadastroLancamentoViewModel>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddMvc(opts =>
{
    opts.Filters.Add(new CustomActionFilter());
    opts.Filters.Add(typeof(CustomActionFilter));  
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(opcao => opcao.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Inicio}/{action=Inicio}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
