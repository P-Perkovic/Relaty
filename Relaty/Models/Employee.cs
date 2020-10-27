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
        public string Name { get; set; }

        public string Mail { get; set; }

        [ForeignKey("Title")]
        public int TitleId { get; set; }

        public Title Title { get; set; }

        public List<Project> Projects { get; set; }
    }
}
