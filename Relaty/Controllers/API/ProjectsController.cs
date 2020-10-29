using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Models;

namespace Relaty.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET api/projects/
        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _context.Projects
                .Include(p => p.Status)
                .ToList();

            if(projects == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
        }

        // GET api/projects/{id}
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _context.Projects
                .Include(p => p.Status)
                .SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = _mapper.Map<ProjectWithEmployeesDto>(project);
            var projectEmployees = _context.ProjectsEmployees
                .Include(pe =>  pe.Employee)
                .Include(pe => pe.Employee.Title)
                .Where(pe => pe.ProjectId == id)
                .ToList();
            projectDto.ProjectsEmployees = _mapper.Map<IEnumerable<ProjectEmployeesDto>>(projectEmployees);

            return Ok(projectDto);
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var projectEmployees = _context.ProjectsEmployees
                .Where(pe => pe.ProjectId == id);


            _context.Projects.Remove(project);
            _context.ProjectsEmployees.RemoveRange(projectEmployees);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
