using AutoMapper;
using managemoney.Models;

namespace managemoney.Repositorios.DTOs.LancamentosDTO
{
    public class MapeamentoLancamentoDTO : Profile
    {
        public MapeamentoLancamentoDTO()
        {
            CreateMap<LancamentoDTO, LancamentoModel>();
        }
    }
}