using System.Text;
using AutoMapper;
using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using managemoney.Repositorios.DTOs.UsuarioDTO;

namespace managemoney.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IMapper _mapper;
        private UserManager<UsuarioModel> _usermanager;

        public UsuarioRepository(IMapper mapper, UserManager<UsuarioModel> userManager, 
                              SignInManager<UsuarioModel> signInManager)
        {
            _mapper = mapper;
            _usermanager = userManager;
        }

        public Task Atualizar(int id, AtualizarUsuarioDTO usuarioDTO)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(CriarUsuarioDTO usuarioDto) 
        {
                var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            
                var resultado = await _usermanager.CreateAsync(usuario, usuarioDto.Senha);
                
                if (!resultado.Succeeded) 
                {
                    var erros = new StringBuilder();
                    foreach(var erro in resultado.Errors) 
                        erros.AppendLine(erro.Description + " ");

                    throw new Exception(erros.ToString());
                }
        }
    }
}