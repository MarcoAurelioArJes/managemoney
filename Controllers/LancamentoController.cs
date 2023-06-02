using managemoney.Models;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.LancamentosDTO;

namespace managemoney.Controllers
{
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private ILancamentoRepository _lancamentoRepository;
        private IUsuarioRepository _usuarioRepository;
        
        public LancamentoController(ILancamentoRepository lancamentoRepository,
                                    IUsuarioRepository usuarioRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("api/[controller]/cadastrar")]
        public ActionResult Criar([FromBody] CriarLancamentoDTO lancamento)
        {
            try
            {
                _lancamentoRepository.Criar(MapeamentoLancamentoDTO.MapeiaCriarLancamento(lancamento));
                return Created("Lancamento criado", null);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost("api/[controller]/atualizar/{id}")]
        public IActionResult Criar(int id, [FromBody] LancamentoModel lancamento)
        {
            try
            {
                _lancamentoRepository.Atualizar(id, lancamento);
                return NoContent();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost("api/[controller]/obterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_lancamentoRepository.ObterTodos());
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost("api/[controller]/obterPorId/{id}")]
        public ActionResult ObterPorId(int id)
        {
            try
            {
                return Ok(_lancamentoRepository.ObterPorId(id));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost("api/[controller]/remover/{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _lancamentoRepository.Remover(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}