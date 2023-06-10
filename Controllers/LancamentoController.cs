using managemoney.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.LancamentosDTO;
using Microsoft.AspNetCore.Authorization;

namespace managemoney.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LancamentoController : Controller
    {
        private IMapper _mapper;
        private ILancamentoRepository _lancamentoRepository;
        private IUsuarioRepository _usuarioRepository;

        public LancamentoController(IMapper mapper,
                                    ILancamentoRepository lancamentoRepository,
                                    IUsuarioRepository usuarioRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public IActionResult Lancamento()
        {
            
            return View();
        }

        [HttpPost("cadastrar")]
        [Authorize]
        public ActionResult Criar([FromBody] LancamentoDTO lancamento)
        {
            try
            {
                _lancamentoRepository.Criar(_mapper.Map<LancamentoModel>(lancamento));
                return Created("Lancamento criado", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar/{id}")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromBody] LancamentoDTO novoLancamento)
        {
            try
            {
                _lancamentoRepository.Atualizar(id, _mapper.Map<LancamentoModel>(novoLancamento));
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterTodos")]
        [Authorize]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_lancamentoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("obterPorId/{id}")]
        [Authorize]
        public ActionResult ObterPorId(int id)
        {
            try
            {
                return Ok(_lancamentoRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remover/{id}")]
        [Authorize]
        public ActionResult Remover(int id)
        {
            try
            {
                _lancamentoRepository.Remover(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}