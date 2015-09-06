using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class UserGroup
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        public HashSet<int> Users { get; }

        public UserGroup(string name, HashSet<int> users)
        {
            Name = name;
            Users = users;
        }
    }
}
