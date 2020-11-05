using Relaty.Models;
using System.Collections.Generic;

namespace Relaty.Dtos
{
    public class EmployeeWithProjectsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public Title Title { get; set; }

        public IEnumerable<EmployeeProjectDto> EmployeeProjects { get; set; }
    }
}
