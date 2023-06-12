using AutoMapper;
using System.Text;
using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;
using managemoney.Repositorios.DTOs.UsuarioDTO;

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

        public Task Atualizar(int id, AtualizarUsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Cadastrar(CadastroUsuarioViewModel usuarioDto) 
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
        
            return await _usermanager.CreateAsync(usuario, usuarioDto.Senha);
        }
    }
}