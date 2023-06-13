using AutoMapper;
using managemoney.Models;
using Microsoft.AspNetCore.Mvc;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using managemoney.Models.ViewModels.Categoria;
using managemoney.Extensions;
using ManageMoney.Constantes;

namespace managemoney.Controllers
{
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

        [HttpGet("categorias")]
        public IActionResult Categorias()
        {
            return View(_mapper.Map<List<CategoriasViewModel>>(_categoriaRepository.ObterTodos()));
        }

        [HttpGet("criarCategoria")]
        public IActionResult CriarCategoria()
        {
            return View();
        }

        [HttpPost("criarCategoria")]
        public IActionResult CriarCategoria([FromForm] CriarCategoriaViewModel categoria)
        {
            try
            {
                _categoriaRepository.Criar(_mapper.Map<CategoriaModel>(categoria));
                this.MostrarMensagem("Categoria cadastrada com sucesso!!!");
                ModelState.Clear();
                return View();
            }
            catch (ArgumentException ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao cadastrar categoria: " + ex.Message, true);
                return View();
            }
            catch (Exception ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao cadastrar categoria", true);
                return View();
            }
        }

        [HttpGet("atualizar/{id}")]
        public IActionResult Atualizar(int id)
        {
            try
            {
                var categoria = _categoriaRepository.ObterPorId(id);
                return View(ConstantesDasViews.ViewCriarCategoria, _mapper.Map<CriarCategoriaViewModel>(categoria));
            }
            catch (ArgumentException ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao cadastrar categoria: " + ex.Message, true);
                var categoria = _categoriaRepository.ObterPorId(id);
                return View(ConstantesDasViews.ViewCriarCategoria, _mapper.Map<CriarCategoriaViewModel>(categoria));
            }
            catch (Exception ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao cadastrar categoria", true);
                var categoria = _categoriaRepository.ObterPorId(id);
                return View(ConstantesDasViews.ViewCriarCategoria, _mapper.Map<CriarCategoriaViewModel>(categoria));
            }
        }

        [HttpPost("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromForm] CriarCategoriaViewModel categoriaView)
        {
            try
            {
                _categoriaRepository.Atualizar(id, _mapper.Map<CategoriaModel>(categoriaView));
                this.MostrarMensagem("Categoria atualizada com sucesso!!!");
                return View(ConstantesDasViews.ViewCriarCategoria, _mapper.Map<CriarCategoriaViewModel>(_categoriaRepository.ObterPorId(id)));
            }
            catch (ArgumentException ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao atualizar categoria: " + ex.Message, true);
                return View(ConstantesDasViews.ViewCriarCategoria, categoriaView);
            }
            catch (Exception ex)
            {
                this.MostrarMensagem("Ocorreu um erro ao atualizar categoria", true);
                return View(ConstantesDasViews.ViewCriarCategoria, categoriaView);
            }
        }

        [HttpGet("remover/{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                _categoriaRepository.Remover(id);
                return View(ConstantesDasViews.ViewCategorias, _mapper.Map<List<CategoriasViewModel>>(_categoriaRepository.ObterTodos()));
            } 
            catch (Exception)
            {
                return View(ConstantesDasViews.ViewCategorias, _mapper.Map<List<CategoriasViewModel>>(_categoriaRepository.ObterTodos()));
            }
        }
    }
}