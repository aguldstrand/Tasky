using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class Sprint
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [StringLength(2000)]
        public string Description { get; }

        public Sprint(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
