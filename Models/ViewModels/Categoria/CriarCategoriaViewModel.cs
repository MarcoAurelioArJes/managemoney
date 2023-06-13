using System.ComponentModel.DataAnnotations;

namespace managemoney.Models.ViewModels.Categoria
{
    public class CriarCategoriaViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        public string Nome { get; set; }
    }
}