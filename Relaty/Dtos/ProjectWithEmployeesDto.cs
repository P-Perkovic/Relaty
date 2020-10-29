using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Dtos
{
    public class ProjectWithEmployeesDto
    {
        public string Name { get; set; }

        public DateTime? DateOfStart { get; set; }

        public Status Status { get; set; }

        public IEnumerable<ProjectEmployeesDto> ProjectsEmployees { get; set; }
    }
}

