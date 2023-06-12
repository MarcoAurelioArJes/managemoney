using managemoney.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.LancamentosDTO;
using Microsoft.AspNetCore.Authorization;
using managemoney.Models.ViewModels.Lancamento;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManageMoney.Constantes;

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

        [HttpGet("lancamentos")]
        public IActionResult Lancamentos()
        {
            var lancamentos = _lancamentoRepository.ObterTodos();  
            return View(_mapper.Map<List<LancamentosViewModel>>(lancamentos));
        }

        [HttpGet("cadastroLancamento")]
        public IActionResult CadastroLancamento()
        {

            return View(ObterCadastroLancamento());
        }

        [HttpPost("cadastrar")]
        public ActionResult Criar([FromForm] CadastroLancamentoViewModel lancamento)
        {
            var model = ObterCadastroLancamento();
            if (lancamento.CategoriaID == 0)
                throw new ArgumentException("Por favor selecione uma categoria");
            try
            {
                _lancamentoRepository.Criar(_mapper.Map<LancamentoModel>(lancamento));
                return View(ConstantesDasViews.ViewCadastroLancamento, model);
            } 
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(ConstantesDasViews.ViewCadastroLancamento, model);
            }
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
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(ConstantesDasViews.ViewCadastroLancamento);
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

        public CadastroLancamentoViewModel ObterCadastroLancamento()
        {
            var viewCadLancamento = new CadastroLancamentoViewModel();
            foreach (var categoria in _categoriaRepository.ObterTodos())
            {
                viewCadLancamento.Categorias.Add(new SelectListItem
                {
                    Text = categoria.Nome,
                    Value = categoria.Id.ToString()
                });
            }

            return viewCadLancamento;
        }
    }
}