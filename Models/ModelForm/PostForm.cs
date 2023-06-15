using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProShots.Models.ModelForm
{
    public class PostForm
    {
        public int? Id { get; set; } = 0;

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }


        public IFormFile? Thumbnail { get; set; } = null;

        [Required]
        public string Status { get; set; }
    }
}
