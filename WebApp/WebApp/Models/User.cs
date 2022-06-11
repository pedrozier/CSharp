using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public Email Email { get; set; }
        [Required]
        public Phone Phone { get; set; }
    }
}
