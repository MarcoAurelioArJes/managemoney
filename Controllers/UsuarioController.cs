using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.UsuarioDTO;
using managemoney.Models;
using Microsoft.AspNetCore.Identity;

namespace managemoney.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        private SignInManager<UsuarioModel> _signInManager;

        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 SignInManager<UsuarioModel> signInManager)
        {
            _usuarioRepository = usuarioRepository;
            _signInManager = signInManager;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CriarUsuarioDTO usuarioDTO)
        {
            try
            {
                await _usuarioRepository.Cadastrar(usuarioDTO);
                return Ok();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUsuarioDTO usuarioDTO)
        {
            try
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuarioDTO.Nome, usuarioDTO.Senha, false, false);
                if (resultado.Succeeded)
                {
                    return LocalRedirect("/Lancamento");
                }

                return RedirectToAction("Login", "Inicio");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }
    }

    public class RespostaJson
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}