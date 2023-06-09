using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.UsuarioDTO;
using managemoney.Services;

namespace managemoney.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        private AutenticacaoUsuarioService _autenticacaoUsuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 AutenticacaoUsuarioService autenticacaoUsuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _autenticacaoUsuarioService = autenticacaoUsuarioService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CriarUsuarioDTO usuarioDTO)
        {
            try
            {
                await _usuarioRepository.Cadastrar(usuarioDTO);
                return Ok();   
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO usuarioDTO)
        {
            try
            {
                var token = await _autenticacaoUsuarioService.Login(usuarioDTO);
                return Ok(token);   
            }
            catch (System.Exception)
            {
                throw;
            }           
        }
    }
}