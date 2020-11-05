using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Models;
using System.Linq;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PUT api/projectemployees
        [HttpPut]
        public IActionResult Update([FromForm] ProjectEmployeesDto projectEmployees)
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
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
