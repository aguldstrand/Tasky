using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class Project
    {
        [Required]
        [MaxLength(140)]
        public string Name { get; }

        [MaxLength(2000)]
        public string Description { get; }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
