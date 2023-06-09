using managemoney.Repositorios.DTOs.UsuarioDTO;

namespace managemoney.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(CriarUsuarioDTO usuarioDTO);
        Task Atualizar(int id, AtualizarUsuarioDTO usuarioDTO);
    }
}