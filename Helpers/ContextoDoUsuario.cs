namespace managemoney.Helpers
{
    public class ContextoDoUsuario
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextoDoUsuario(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ObterIdDoUsuarioAtual()
        {
            var contexto = _httpContextAccessor.HttpContext;
            return contexto.User.Claims.FirstOrDefault(c => c.Type == "id").Value;
        }
    }
}