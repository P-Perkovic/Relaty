using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Dtos
{
    public class EmployeeWithProjectsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public Title Title { get; set; }

        public IEnumerable<EmployeeProjectsDto> EmployeeProjects { get; set; }
    }
}
