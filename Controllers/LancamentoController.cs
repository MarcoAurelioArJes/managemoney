using managemoney.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.LancamentosDTO;
using Microsoft.AspNetCore.Authorization;
using managemoney.Models.ViewModels.Lancamento;

namespace managemoney.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class LancamentoController : Controller
    {
        private IMapper _mapper;
        private ILancamentoRepository _lancamentoRepository;
        private IUsuarioRepository _usuarioRepository;
        private ICategoriaRepository _categoriaRepository;

        public LancamentoController(IMapper mapper,
                                    ILancamentoRepository lancamentoRepository,
                                    IUsuarioRepository usuarioRepository,
                                    ICategoriaRepository categoriaRepository)
        {
            _lancamentoRepository = lancamentoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("lancamento")]
        public IActionResult Lancamento()
        {
            var lancamentos = _lancamentoRepository.ObterTodos();  
            return View(_mapper.Map<List<LancamentosViewModel>>(lancamentos));
        }

        [HttpGet("cadastroLancamento")]
        public IActionResult CadastroLancamento()
        {
            var viewCadLancamento = new CadastroLancamentoViewModel(_categoriaRepository);
            viewCadLancamento.Categorias = _categoriaRepository.ObterTodos();
            return View(viewCadLancamento);
        }

        [HttpPost("cadastrar")]
        public ActionResult Criar([FromForm] CadastroLancamentoViewModel lancamento)
        {
            _lancamentoRepository.Criar(_mapper.Map<LancamentoModel>(lancamento));
            return View("~/Views/Lancamento/CadastroLancamento.cshtml");
        }

        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromForm] LancamentoDTO novoLancamento)
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

        [HttpGet("obterPorId/{id}")]
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