using System.ComponentModel.DataAnnotations;

namespace apiemail.Models
{
    public class EmailModel
    {
    public int Id {get;set;}
        [Required]
    public string TargetEmail { get;set;}
        [Required]
    public string Subject {get;set;}
        [Required]
    public string Body {get;set;}

    }

}
