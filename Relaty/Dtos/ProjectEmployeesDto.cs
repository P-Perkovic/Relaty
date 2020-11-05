using System.Collections.Generic;

namespace Relaty.Dtos
{
    public class ProjectEmployeesDto
    {
        public int ProjectId { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}
