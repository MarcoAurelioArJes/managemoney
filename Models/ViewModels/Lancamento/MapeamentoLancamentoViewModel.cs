using AutoMapper;
using managemoney.Models;
using managemoney.Models.Interfaces;
using managemoney.Repositorios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace managemoney.Models.ViewModels.Lancamento
{
    public class MapeamentoLancamentoViewModel : Profile
    {
        public MapeamentoLancamentoViewModel()
        {
            CreateMap<LancamentoModel, LancamentosViewModel>();
            CreateMap<CadastroLancamentoViewModel, LancamentoModel>();
            CreateMap<LancamentoModel, CadastroLancamentoViewModel>()
                    .ForMember(
                        dest => dest.Categorias,
                        opts => opts.MapFrom(src => MapSelectItem(src.Categoria)));
        }

        private List<SelectListItem> MapSelectItem(CategoriaModel categoriaModel)
        {
            return new List<SelectListItem> {
                        new SelectListItem
                        {
                            Value = categoriaModel.Id.ToString(),
                            Text = categoriaModel.Nome
                        }};
        }
    }
}