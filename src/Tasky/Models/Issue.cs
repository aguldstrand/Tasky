using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class Issue
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [StringLength(2000)]
        public string Description { get; }

        [Required]
        public int Author { get; }

        [Required]
        public int Assignee { get; }

        public Issue(string name, string description, int author, int assignee)
        {
            Name = name;
            Description = description;
            Author = author;
            Assignee = assignee;
        }
    }
}
