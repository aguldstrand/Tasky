using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class AccessEntry
    {
        [Required]
        public int Group { get; }

        [Required]
        public Access Access { get; }

        public AccessEntry(int group, Access access)
        {
            Group = group;
            Access = access;
        }
    }
}
