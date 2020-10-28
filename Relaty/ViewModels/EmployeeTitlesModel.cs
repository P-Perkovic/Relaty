using Relaty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.ViewModels
{
    public class EmployeeTitlesModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Title> Titles { get; set; }
    }
}
