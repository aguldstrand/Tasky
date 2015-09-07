using System.ComponentModel.DataAnnotations;

namespace Tasky.Api.Models
{
    public class Attachment
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string Filename { get; }

        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string ContentType { get; }

        [Required]
        [StringLength(1024 * 1024 * 30, MinimumLength = 1)] // ~30MB
        public string Base64Data { get; }

        public Attachment(string filename, string contentType, string base64Data)
        {
            Filename = filename;
            Base64Data = base64Data;
        }
    }
}
