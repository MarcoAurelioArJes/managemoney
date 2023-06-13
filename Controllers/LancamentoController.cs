using managemoney.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using managemoney.Repositorios.DTOs.LancamentosDTO;
using Microsoft.AspNetCore.Authorization;
using managemoney.Models.ViewModels.Lancamento;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManageMoney.Constantes;
using managemoney.Filters;
using managemoney.Extensions;

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
        [CustomActionFilter(Order = 5)]
        public IActionResult Lancamentos()
        {
            var lancamentos = _lancamentoRepository.ObterTodos();  
            return View(_mapper.Map<List<LancamentosViewModel>>(lancamentos));
        }

        [HttpGet("cadastrarLancamento")]
        public IActionResult CadastrarLancamento()
        {

            return View(ObterCadastroLancamento());
        }

        [HttpGet("detalhesLancamento/{id}")]
        public IActionResult DetalhesLancamento(int id)
        {
            try
            {
                var lancamento = _lancamentoRepository.ObterPorId(id);  
                return View(_mapper.Map<LancamentosViewModel>(lancamento));
            }
            catch (Exception)
            {
                return View(ConstantesDasViews.ViewLancamentos);
            }
        }

        [HttpPost("cadastrar")]
        public ActionResult Cadastrar([FromForm] CadastroLancamentoViewModel lancamento)
        {
            var model = ObterCadastroLancamento();
            try
            {
                if (lancamento.CategoriaID == 0)
                    throw new ArgumentException("Por favor selecione uma categoria");
                
                _lancamentoRepository.Criar(_mapper.Map<LancamentoModel>(lancamento));
                this.MostrarMensagem("Lançamento cadastrado com sucesso");
                ModelState.Clear();
                return View(ConstantesDasViews.ViewCadastrarLancamento, model);
            } 
            catch (Exception ex) 
            {
                this.MostrarMensagem("Erro ao cadastrar lançamento! Tente novamente.", true);
                return View(ConstantesDasViews.ViewCadastrarLancamento, model);
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
                return View(ConstantesDasViews.ViewCadastrarLancamento);
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