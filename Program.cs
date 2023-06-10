using System.Text;
using managemoney.Models;
using managemoney.Helpers;
using managemoney.Services;
using managemoney.Repositorios;
using managemoney.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

builder.Services.AddAuthentication(opts => 
{
    opts.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opts => 
{
    opts.TokenValidationParameters = 
    new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asDASD@#%#SDASPOAOSD@#!213213asdasDASDASDASDSAd")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ContextoDoUsuario>();
builder.Services.AddScoped<GeradorDeTokenService>();
builder.Services.AddScoped<AutenticacaoUsuarioService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddMvc(opts => 
{
    opts.EnableEndpointRouting = false;
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(opcao => opcao.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();

app.Run();
