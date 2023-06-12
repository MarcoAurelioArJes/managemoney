using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.UsuarioDTO;
using managemoney.Models;
using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;

namespace managemoney.Controllers
{
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
        public async Task<IActionResult> Cadastrar([FromForm] CadastroUsuarioViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                var resultado = await _usuarioRepository.Cadastrar(usuario);
                if (!resultado.Succeeded) 
                {
                    foreach(var erro in resultado.Errors) 
                        ModelState.AddModelError(erro.Code, erro.Description);
                }
                return View("~/Views/Inicio/Login.cshtml");
            }

            return View("~/Views/Inicio/Cadastro.cshtml");    
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuario.Nome, usuario.Senha, usuario.LembrarSenha, false);
                if (resultado.Succeeded)
                {
                    return LocalRedirect("/lancamento/lancamentos");
                }
            }

            return View("~/Views/Inicio/Login.cshtml");
        }

        public async Task<IActionResult> Logout([FromForm] LoginViewModel usuario)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Inicio", "Inicio");
        }
    }

    public class RespostaJson
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}