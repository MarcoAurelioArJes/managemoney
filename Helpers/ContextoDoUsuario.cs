using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace managemoney.Helpers
{
    public class ContextoDoUsuario
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UserManager<UsuarioModel> _usermanager;
        private HttpContext? _httpContext;

        public ContextoDoUsuario(IHttpContextAccessor httpContextAccessor,
                                 UserManager<UsuarioModel> usermanager)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = _httpContextAccessor?.HttpContext;
            _usermanager = usermanager;
        }
        public string ObterIdDoUsuarioAtual()
        {
            var identity = _httpContext.User.Identity;
            if (identity != null)
            {
                string nomeUsuario = identity.Name ?? string.Empty;
                var usuarioAutenticado = _usermanager.Users.FirstOrDefault(u => u.NormalizedUserName == nomeUsuario.ToUpper()) ?? new UsuarioModel();
                return usuarioAutenticado.Id;
            }

            return string.Empty;
        }

        public bool UsuarioEstaAutenticado()
        {
            if (_httpContext.User.Identity != null)
            {
                return _httpContext.User.Identity.IsAuthenticated;
            }
            return false;
        }

        public UsuarioModel ObterUsuarioAtual()
        {
            return _usermanager.Users.FirstOrDefault(c => c.NormalizedEmail == _httpContext.User.Identity.Name.ToUpper());
        }
    }
}