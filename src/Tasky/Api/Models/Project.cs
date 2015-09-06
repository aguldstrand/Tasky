using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class Project
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [StringLength(2000)]
        public string Description { get; }

        [Required]
        public ImmutableHashSet<AccessEntry> AccessControl { get; }

        public Project(string name, string description, ImmutableHashSet<AccessEntry> accessControl)
        {
            Name = name;
            Description = description;
            AccessControl = accessControl;
        }
    }
}
