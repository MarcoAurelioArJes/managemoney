using AutoMapper;
using managemoney.Models;

namespace managemoney.Repositorios.DTOs.UsuarioDTO
{
    public class MapeamentoUsuarioDTO : Profile
    {
        public MapeamentoUsuarioDTO()
        {
            CreateMap<CriarUsuarioDTO, UsuarioModel>()
            .ForMember(
                model => model.UserName,
                dto => dto.MapFrom(c => c.Nome)
            );
        }
    }
}