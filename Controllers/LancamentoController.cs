using AutoMapper;
using managemoney.Models;
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
        public ActionResult Criar([FromBody] CriarLancamentoDTO lancamento)
        {
            try
            {
                _lancamentoRepository.Criar(_mapper.Map<LancamentoModel>(lancamento));
                return Created("Lancamento criado", null);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost("atualizar/{id}")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromBody] LancamentoModel lancamento)
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

        [HttpGet("obterTodos")]
        [Authorize]
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

        [HttpGet("obterPorId/{id}")]
        [Authorize]
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

        [HttpDelete("remover/{id}")]
        [Authorize]
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