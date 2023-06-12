using Microsoft.AspNetCore.Identity;
using managemoney.Models.ViewModels.Usuario;
using managemoney.Repositorios.DTOs.UsuarioDTO;

namespace managemoney.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IdentityResult> Cadastrar(CadastroUsuarioViewModel usuario);
        Task Atualizar(int id, AtualizarUsuarioDTO usuario);
    }
}