using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Models;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PUT api/employeeprojects
        [HttpPut]
        public IActionResult Update([FromForm]EmployeeProjectsDto employeeProjects)
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
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
