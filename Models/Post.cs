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


        public string Thumbnail { get; set; }

        [Required] 
        public string Status { get;set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int User { get; set; }

        [Required]      
        public DateTime CreatedAt { get; set;}= DateTime.Now;

    }
    
}
