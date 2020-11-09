using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Hubs;
using Relaty.Models;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAppHub _appHub;

        public EmployeeProjectsController(ApplicationDbContext context, IAppHub appHub)
        {
            _context = context;
            _appHub = appHub;
        }

        // PUT api/employeeprojects
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm]EmployeeProjectsDto employeeProjects)
        {
            var projectsDb = _context.ProjectsEmployees
                .Where(ep => ep.EmployeeId == employeeProjects.EmployeeId)
                .Select(ep => ep.ProjectId)
                .ToList();
            var projectsToDelete = projectsDb.Except(employeeProjects.ProjectIds).ToList();
            var projectsToAdd = employeeProjects.ProjectIds.Except(projectsDb).ToList();

            var employeProject = new ProjectEmployee
            {
                EmployeeId = employeeProjects.EmployeeId
            };

            foreach (var projectId in projectsToDelete)
            {
                employeProject.ProjectId = projectId;
                _context.ProjectsEmployees.Remove(employeProject);
                _context.SaveChanges();
            }

            foreach (var projectId in projectsToAdd)
            {
                employeProject.ProjectId = projectId;
                _context.ProjectsEmployees.Add(employeProject);
                _context.SaveChanges();
            }

            await _appHub.Refresh();

            return Ok();
        }
    }
}
