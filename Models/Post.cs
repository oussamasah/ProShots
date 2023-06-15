using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }


        public string Thumbnail { get; set; }= "/post_thumbnail.jpg";

        [Required] 
        public string Status { get;set; }

        public int like { get; set; } = 0;
        public int dislike { get; set; } = 0;

        [Required]
        [ForeignKey(nameof(User))]
        public string User { get; set; }

        [Required]      
        public DateTime CreatedAt { get; set;}= DateTime.Now;

    }
    
}
