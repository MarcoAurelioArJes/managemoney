using AutoMapper;
using managemoney.Models;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class MapeamentoLancamentoViewModel : Profile
    {
        public MapeamentoLancamentoViewModel()
        {
            CreateMap<LancamentoModel, LancamentosViewModel>();
            CreateMap<CadastroLancamentoViewModel, LancamentoModel>();
        }
    }
}