using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models.ModelForm
{
    public class GalleryForm
    {

        public int  Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Sector { get; set; }
        [NotMapped]
       
        public IFormFile Images { get; set; }
     

       
    }
}
