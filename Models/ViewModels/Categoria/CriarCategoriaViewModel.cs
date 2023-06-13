using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Categoria
{
    public class CriarCategoriaViewModel
    {
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        public string Nome { get; set; }
    }
}