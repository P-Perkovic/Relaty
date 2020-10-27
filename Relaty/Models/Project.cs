using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Models
{
    public class Project
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime? DateOfStart { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<ProjectEmployee> ProjectsEmployees { get; set; }
    }
}
