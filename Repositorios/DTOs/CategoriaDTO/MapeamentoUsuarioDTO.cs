using AutoMapper;
using managemoney.Models;

namespace managemoney.Repositorios.DTOs.CategoriaDTO
{
    public class MapeamentoCategoriaDTO : Profile
    {
        public MapeamentoCategoriaDTO()
        {
            CreateMap<CriarCategoriaDTO, CategoriaModel>();
            CreateMap<CategoriaModel, CategoriasDTO>();
        }
    }
}