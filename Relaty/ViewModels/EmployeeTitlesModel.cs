using Relaty.Models;
using System.Collections.Generic;

namespace Relaty.ViewModels
{
    public class EmployeeTitlesModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Title> Titles { get; set; }
        public string ViewName;
    }
}
