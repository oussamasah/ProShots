using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CammentId { get; set; } = 0;
        [Required]
        public string Content { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey(nameof(Post))]
        public int Post { get; set; }
        [Required]  
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
