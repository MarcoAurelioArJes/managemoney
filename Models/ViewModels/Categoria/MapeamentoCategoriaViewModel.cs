using AutoMapper;
using managemoney.Models;

namespace managemoney.Models.ViewModels.Categoria
{
    public class MapeamentoCategoriaViewModel : Profile
    {
        public MapeamentoCategoriaViewModel()
        {
            CreateMap<CriarCategoriaViewModel, CategoriaModel>();
            CreateMap<CategoriaModel, CategoriasViewModel>();
            CreateMap<CategoriaModel, CriarCategoriaViewModel>();
            
        }
    }
}