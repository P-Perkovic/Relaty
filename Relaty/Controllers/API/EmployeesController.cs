using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relaty.Data;
using Relaty.Dtos;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees
                .Include(e => e.Title)
                .ToList();

            if(employees == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        // GET api/employees/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _context.Employees
                .Include(e => e.Title)
                .SingleOrDefault(e => e.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            var employeeDto = _mapper.Map<EmployeeWithProjectsDto>(employee);
            var employeeProjects = _context.ProjectsEmployees
                .Include(pe => pe.Project)
                .Include(pe  => pe.Project.Status)
                .Where(pe => pe.EmployeeId == id)
                .ToList();
            employeeDto.EmployeeProjects = _mapper.Map<IEnumerable<EmployeeProjectDto>>(employeeProjects);

            return Ok(employeeDto);
            
        }

        // DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees
                .SingleOrDefault(e => e.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            var employeeProjects = _context.ProjectsEmployees
                .Where(pe => pe.EmployeeId == id);

            _context.Remove(employee);
            _context.RemoveRange(employeeProjects);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
