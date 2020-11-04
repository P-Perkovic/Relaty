using System.ComponentModel.DataAnnotations;

namespace Relaty.Models
{
    public class Title
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
