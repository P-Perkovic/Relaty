using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
