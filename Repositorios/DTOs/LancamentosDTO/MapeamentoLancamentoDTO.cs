using AutoMapper;
using managemoney.Models;

namespace managemoney.Repositorios.DTOs.LancamentosDTO
{
    public static class MapeamentoLancamentoDTO
    {
        public static LancamentoModel MapeiaCriarLancamento(CriarLancamentoDTO lancamentoDTO)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<CriarLancamentoDTO, LancamentoModel>());
            var mapper = configuration.CreateMapper();
            return mapper.Map<LancamentoModel>(lancamentoDTO);
        }
    }
}