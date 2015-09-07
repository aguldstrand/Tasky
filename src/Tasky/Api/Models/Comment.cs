using System.ComponentModel.DataAnnotations;

namespace Tasky.Api.Models
{
    public class Comment
    {
        [Required]
        [StringLength(2000, MinimumLength = 1)]
        public string Text { get; }

        [Required]
        public int Author { get; }

        public Comment(string text, int author)
        {
            Text = text;
            Author = author;
        }
    }
}