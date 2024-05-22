using System.ComponentModel.DataAnnotations;

namespace Spacdyna.Models
{
    public class Provide
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
