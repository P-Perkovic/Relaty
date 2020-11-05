using System.Collections.Generic;

namespace Relaty.Dtos
{
    public class EmployeeProjectsDto
    {
        public int EmployeeId { get; set; }
        public List<int> ProjectIds { get; set; }
    }
}
