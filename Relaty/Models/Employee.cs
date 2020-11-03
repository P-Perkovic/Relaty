using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Title")]
        [Range(1, 8, ErrorMessage ="Select employee title")]
        public int TitleId { get; set; }

        public Title Title { get; set; }

        public ICollection<ProjectEmployee> ProjectsEmployees { get; set; }
    }
}
