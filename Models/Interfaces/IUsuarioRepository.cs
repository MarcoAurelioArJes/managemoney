using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;

namespace managemoney.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IdentityResult> Cadastrar(CadastroUsuarioViewModel usuario);
        Task Atualizar(int id, CadastroUsuarioViewModel usuario);
    }
}