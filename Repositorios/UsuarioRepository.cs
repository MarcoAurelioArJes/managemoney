using AutoMapper;
using System.Text;
using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;
using Microsoft.EntityFrameworkCore;

namespace managemoney.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IMapper _mapper;
        private UserManager<UsuarioModel> _usermanager;

        public UsuarioRepository(IMapper mapper, 
                                UserManager<UsuarioModel> userManager, 
                                SignInManager<UsuarioModel> signInManager)
        {
            _mapper = mapper;
            _usermanager = userManager;
        }

        public Task Atualizar(int id, CadastroUsuarioViewModel usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Cadastrar(CadastroUsuarioViewModel novoUsuario) 
        {
            ValidarSeJaExisteEmail(novoUsuario);
            ValidarSeJaExisteNomeDoUsuario(novoUsuario);
            var usuario = _mapper.Map<UsuarioModel>(novoUsuario);
        
            return await _usermanager.CreateAsync(usuario, usuario.Senha);
        }

        public void ValidarSeJaExisteEmail(CadastroUsuarioViewModel usuarioEmail)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioEmail);
            var usuarioComEmail = _usermanager.Users.FirstOrDefault(u => u.Email.ToUpper() == usuarioEmail.Email.ToUpper());
            if (usuarioComEmail != null)
                throw new ArgumentException("Já existe um usuário com esse email");

        }
        public void ValidarSeJaExisteNomeDoUsuario(CadastroUsuarioViewModel usuarioEmail)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioEmail);
            var usuarioComEmail = _usermanager.Users.FirstOrDefault(u => u.NormalizedUserName == usuarioEmail.NomeUsuario.ToUpper());
            if (usuarioComEmail != null)
                throw new ArgumentException("Já existe um usuário com esse nome");

        }
    }
}