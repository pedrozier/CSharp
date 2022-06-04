using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Category
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

    }
}