using System.ComponentModel.DataAnnotations;

namespace APITesteCSharp.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public String Description { get; set; }

        public Priority priority { get; set; }

        public IssueType type { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Completted { get; set; }
    }

    public enum Priority
    {
        Low,Medium,High
    }
    public enum IssueType
    {
        Feature,Bug,Documentation
    }

}
