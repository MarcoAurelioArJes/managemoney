using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace managemoney.Helpers
{
    public class ContextoDoUsuario
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<UsuarioModel> _usermanager;

        public ContextoDoUsuario(IHttpContextAccessor httpContextAccessor,
                                 UserManager<UsuarioModel> usermanager)
        {
            _httpContextAccessor = httpContextAccessor;
            _usermanager = usermanager;
        }
        public string ObterIdDoUsuarioAtual()
        {
            var contexto = _httpContextAccessor.HttpContext;
            return _usermanager.Users.FirstOrDefault(u => u.NormalizedUserName == contexto.User.Identity.Name.ToUpper())?.Id;
        }
    }
}