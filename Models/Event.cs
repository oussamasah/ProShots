using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Sector))]
        public int Sector { get; set; } = 18;

        [Required]
        [ForeignKey(nameof(User))]
        public string User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
