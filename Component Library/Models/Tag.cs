using System.ComponentModel.DataAnnotations;

namespace Component_Library.Models
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
