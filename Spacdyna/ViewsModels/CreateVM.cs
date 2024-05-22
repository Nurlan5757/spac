using System.ComponentModel.DataAnnotations;

namespace Spacdyna.ViewsModels
{
    public class CreateVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Subtitle { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
