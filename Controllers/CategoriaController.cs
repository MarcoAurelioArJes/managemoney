using AutoMapper;
using managemoney.Models;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using managemoney.Models.ViewModels.Categoria;

namespace managemoney.Controllers
{
    [Route("[Controller]")]
    [Authorize]
    public class CategoriaController : Controller
    {
        private IMapper _mapper;
        private ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository,
                                   IMapper mapper) 
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet("criarCategoria")]
        public IActionResult CadastroCategoria()
        {
            return View();
        }

        [HttpPost("criarCategoria")]
        public IActionResult CriarCategoria([FromForm] CriarCategoriaViewModel categoria)
        {
            try
            {
                _categoriaRepository.Criar(_mapper.Map<CategoriaModel>(categoria));
                return Ok();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterTodas")]
        public IActionResult ObterTodas()
        {
            try
            {
                return Ok(_mapper.Map<List<CategoriasViewModel>>(_categoriaRepository.ObterTodos()));
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _categoriaRepository.Remover(id);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}