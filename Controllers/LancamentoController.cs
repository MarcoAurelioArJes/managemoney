using managemoney.Models;
using managemoney.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("api/[controller]/cadastrarLancamento")]
        public ActionResult Criar([FromBody] LancamentoModel lancamento)
        {
            try
            {
                _lancamentoRepository.Criar(lancamento);
                return Ok();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}