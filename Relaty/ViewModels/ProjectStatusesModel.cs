using Relaty.Models;
using System.Collections.Generic;

namespace Relaty.ViewModels
{
    public class ProjectStatusesModel
    {
        public Project Project { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<int> EmployeeIds { get; set; }
        public string ViewName; 
    }
}
