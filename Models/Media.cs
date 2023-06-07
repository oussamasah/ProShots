using ProShots.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models
{
    public class Media
    {
        [Key]
        public Guid Id { get; set; }
       
        [StringLength(50)]
        public string Title { get; set; }=  String.Empty;
       
        [StringLength(50)]
        public string Description { get; set; } = String.Empty;
        [Required]
        public string Path { get; set; }
    
        public string Tag { get; set; }=string.Empty;
        [Required]
        [ForeignKey(nameof(Event))]
        public int Event { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string User { get; set; }
        [Required]
        public string State { get; set; } = "Public";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
