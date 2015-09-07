using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Api.Models
{
    public class UserGroup
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [Required]
        [MinLength(0)]
        public ImmutableHashSet<int> Users { get; }

        public UserGroup(string name, ImmutableHashSet<int> users)
        {
            Name = name;
            Users = users;
        }
    }
}
