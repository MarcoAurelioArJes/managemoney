using System.ComponentModel.DataAnnotations;

namespace managemoney.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}