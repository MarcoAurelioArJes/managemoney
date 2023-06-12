using AutoMapper;
using managemoney.Helpers;
using managemoney.Models.Interfaces;
using managemoney.Models.ViewModels.Lancamento;
using ManageMoney.Constantes;
using Microsoft.AspNetCore.Mvc;

namespace ManageMoney.Controllers
{
    public class InicioController : Controller
    {

        public ContextoDoUsuario _contextoDoUsuario;
        private ILancamentoRepository _lancamentoRepository;
        private IMapper _mapper;

        public InicioController(ContextoDoUsuario contextoDoUsuario,
                                ILancamentoRepository lancamentoRepository,
                                IMapper mapper)
        {
            _contextoDoUsuario = contextoDoUsuario;
            _lancamentoRepository = lancamentoRepository;
            _mapper = mapper;
        }


        public IActionResult Inicio()
        {
            return RetornoViewPadraoSeUsuarioEstiverAutenticado() ?? View();
        }


        public IActionResult Cadastro()
        {
            return RetornoViewPadraoSeUsuarioEstiverAutenticado() ?? View();
        }


        public IActionResult Login()
        {
            return RetornoViewPadraoSeUsuarioEstiverAutenticado() ?? View();
        }

        public ViewResult RetornoViewPadraoSeUsuarioEstiverAutenticado()
        {
            var lancamentos = _lancamentoRepository.ObterTodos();
            if (_contextoDoUsuario.UsuarioEstaAutenticado())
                return View(ConstantesDasViews.ViewLancamentos, _mapper.Map<List<LancamentosViewModel>>(lancamentos));

            return null;
        }
    }
}
