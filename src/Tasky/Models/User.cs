using System.ComponentModel.DataAnnotations;

namespace Tasky.Models
{
    public class User
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [StringLength(140)]
        public string Email { get; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
