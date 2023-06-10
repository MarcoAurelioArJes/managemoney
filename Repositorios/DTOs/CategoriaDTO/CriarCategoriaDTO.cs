using System.ComponentModel.DataAnnotations;

namespace managemoney.Repositorios.DTOs.CategoriaDTO
{
    public class CriarCategoriaDTO
    {
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        public string Nome { get; set; }
    }
}