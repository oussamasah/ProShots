using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; } = 0;
        [Required]
        public string Content { get; set; }

        [Required]
        public string Email { get; set; }

        public int like { get; set; } = 0;
        public int dislike { get; set; } = 0;

        [ForeignKey(nameof(Post))]
        public int Post { get; set; }
        [Required]  
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
