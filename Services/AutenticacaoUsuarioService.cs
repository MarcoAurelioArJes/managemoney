using managemoney.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using managemoney.Repositorios.DTOs.UsuarioDTO;

namespace managemoney.Services
{
    public class AutenticacaoUsuarioService
    {
        private SignInManager<UsuarioModel> _signInManager;
        private GeradorDeTokenService _geradorDeTokenService;

        public AutenticacaoUsuarioService(SignInManager<UsuarioModel> signInManager,
                                   GeradorDeTokenService geradorDeTokenService) 
        {
            _signInManager = signInManager;
            _geradorDeTokenService = geradorDeTokenService;
        }

        public async Task<string> Login(LoginUsuarioDTO usuarioDto) 
        {
                var resultado = await _signInManager.PasswordSignInAsync(usuarioDto.Nome, usuarioDto.Senha, false, false);

                if (!resultado.Succeeded) 
                {
                    throw new ApplicationException("Usuário não autenticado!!!");
                }

                var claims = new Claim[] {
                    new Claim("username", usuarioDto.Nome)
                };

                var usuario = _signInManager
                                .UserManager
                                .Users.FirstOrDefault(u => u.NormalizedUserName == usuarioDto.Nome.ToUpper());
                
                return _geradorDeTokenService.GerarToken(usuario);
        }
    }
}