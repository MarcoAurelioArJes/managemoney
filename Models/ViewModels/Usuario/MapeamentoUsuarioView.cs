using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace managemoney.Models.ViewModels.Usuario
{
    public class MapeamentoUsuarioView : Profile
    {
        public MapeamentoUsuarioView()
        {
            CreateMap<CadastroUsuarioViewModel, UsuarioModel>()
            .ForMember(
                model => model.UserName,
                dto => dto.MapFrom(c => c.NomeUsuario)
            );
        }
    }
}