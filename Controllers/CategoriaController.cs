using managemoney.Models;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;

namespace managemoney.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost("criarCategoria")]
        public IActionResult CriarCategoria([FromBody] CategoriaModel categoria)
        {
            try
            {
                _categoriaRepository.Criar(categoria);
                return Ok();
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }

        [HttpGet("obterTodas")]
        public IActionResult ObterTodas()
        {
            try
            {
                return Ok(_categoriaRepository.ObterTodos());
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}