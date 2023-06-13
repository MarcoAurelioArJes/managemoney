using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Models;
using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;
using ManageMoney.Constantes;
using managemoney.Extensions;

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
            try
            {
                if (ModelState.IsValid)
                {
                    var resultado = await _usuarioRepository.Cadastrar(usuario);
                    if (!resultado.Succeeded)
                    {
                        foreach (var erro in resultado.Errors)
                            ModelState.AddModelError(erro.Code, erro.Description);
                    }
                    return View(ConstantesDasViews.ViewLoginUsuario);
                }

                return View(ConstantesDasViews.ViewCadastroUsuario, usuario);
            } 
            catch (ArgumentException ex)
            {
                this.MostrarMensagem(ex.Message, true);
                return View(ConstantesDasViews.ViewCadastroUsuario, usuario);
            }
            catch (Exception ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao cadastrar o usuário", true);
                return View(ConstantesDasViews.ViewCadastroUsuario, usuario);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuario.NomeUsuario, usuario.Senha, usuario.LembrarSenha, false);
                if (resultado.Succeeded)
                {
                    return LocalRedirect("/lancamento/lancamentos");
                }
                else
                {
                    this.MostrarMensagem("Falha ao fazer login!!! Nome de usuário ou senha inválidos", true);
                    return View(ConstantesDasViews.ViewLoginUsuario, usuario);
                }
            }

            return View(ConstantesDasViews.ViewLoginUsuario);
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