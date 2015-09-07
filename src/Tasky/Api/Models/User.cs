using System.ComponentModel.DataAnnotations;

namespace Tasky.Api.Models
{
    public class User
    {
        [Required]
        [StringLength(140)]
        public string Email { get; }

        [StringLength(140, MinimumLength = 1)]
        public string Name { get; }

        [Required]
        [StringLength(44, MinimumLength = 44)]
        public string Password { get; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
