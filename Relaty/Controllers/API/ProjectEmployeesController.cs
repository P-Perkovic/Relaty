using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Hubs;
using Relaty.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppHub _appHub;

        public ProjectEmployeesController(ApplicationDbContext context, IAppHub appHub)
        {
            _context = context;
            _appHub = appHub;
        }

        // PUT api/projectemployees
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] ProjectEmployeesDto projectEmployees)
        {
            var employeesDb = _context.ProjectsEmployees
                .Where(pe => pe.ProjectId == projectEmployees.ProjectId)
                .Select(pe => pe.EmployeeId)
                .ToList();
            var employeesToDelete = employeesDb.Except(projectEmployees.EmployeeIds);
            var employeesToAdd = projectEmployees.EmployeeIds.Except(employeesDb);

            var projectEmploye = new ProjectEmployee
            {
                ProjectId = projectEmployees.ProjectId,
            };

            foreach (var employee in employeesToDelete)
            {
                projectEmploye.EmployeeId = employee;
                _context.ProjectsEmployees.Remove(projectEmploye);
                _context.SaveChanges();
            }

            foreach (var employee in employeesToAdd)
            {
                projectEmploye.EmployeeId = employee;
                _context.ProjectsEmployees.Add(projectEmploye);
                _context.SaveChanges();
            }

            await _appHub.Refresh();

            return Ok();
        }
    }
}
