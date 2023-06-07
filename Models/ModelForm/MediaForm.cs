using System.ComponentModel.DataAnnotations.Schema;

namespace ProShots.Models.ModelForm
{
    public class MediaForm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = String.Empty;

        public string Tag { get; set; } = string.Empty;

        public int Event { get; set; }

        public string State { get; set; } = "Public";
    }
}
