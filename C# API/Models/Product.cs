using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "este campo deve conter no maximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "o preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "categoria invalida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}