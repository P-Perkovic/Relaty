using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Relaty.Models
{
    public class Project
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Start")]
        [DataType(DataType.Date)]
        public DateTime? DateOfStart { get; set; }

        [Display(Name = "Status")]
        [Required]
        [Range(1, 5, ErrorMessage = "Select project status.")]
        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<ProjectEmployee> ProjectsEmployees { get; set; }
    }
}
