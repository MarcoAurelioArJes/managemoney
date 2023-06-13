using Microsoft.AspNetCore.Mvc;
using managemoney.Models.ViewModels.Mensagem;

namespace managemoney.Extensions
{
    public static class ControllerMensagem
    {
        public static void MostrarMensagem(this Controller @this, string texto, bool erro = false)
        {
            @this.TempData["mensagem"] = MensagemViewModel.Serializar(
                texto, erro ? TipoMensagem.Erro : TipoMensagem.Informacao);
        }
    }
}