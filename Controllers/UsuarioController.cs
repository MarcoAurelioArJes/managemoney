using managemoney.Models;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;

namespace managemoney.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("api/[controller]/criar")]
        public ActionResult Cadastrar([FromBody] UsuarioModel usuario)
        {
            try
            {
                _usuarioRepository.Criar(usuario);
                return Ok();   
            }
            catch (System.Exception)
            {
                throw;
            }           
        }

        [HttpPut("api/[controller]/editar/{id}")]
        public ActionResult Atualizar(int id, [FromBody] UsuarioModel novoUsuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, novoUsuario);
                return Ok();   
            }
            catch (System.Exception erro)
            {
                return BadRequest(erro);
            }           
        }
    }
}