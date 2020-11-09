using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relaty.Data;
using Relaty.Hubs;
using Relaty.Models;
using Relaty.ViewModels;

namespace Relaty.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAppHub _appHub;

        public ProjectsController(ApplicationDbContext context, IMapper mapper, IAppHub appHub)
        {
            _context = context;
            _mapper = mapper;
            _appHub = appHub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            var statuses = _context.Statuses.ToList();
            var viewModel = new ProjectStatusesModel
            {
                Project = new Project(),
                Statuses = statuses,
                ViewName = "New"
            };

            return View("ProjectForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(Project project)
        {

            if(ModelState.IsValid == false)
            {
                var statuses = _context.Statuses.ToList();
                string viewName;
                if (project.Id == 0)
                {
                    viewName = "New";
                }
                else
                {
                    viewName = "Update";
                }
                var viewModel = new ProjectStatusesModel
                {
                    Project = project,
                    Statuses = statuses,
                    ViewName = viewName
                };

                return View("New", viewModel);
            }

            if (project.Id == 0)
            {
                _context.Add(project);
            }
            else
            {
                var projectDb = _context.Projects.SingleOrDefault(p => p.Id == project.Id);
                _mapper.Map(project, projectDb);
            }

            _context.SaveChanges();

            await _appHub.Refresh();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var project = _context.Projects.
                Include(p => p.Status).
                SingleOrDefault(p => p.Id == id);
            project.ProjectsEmployees = _context.ProjectsEmployees
                .Include(pe => pe.Employee)
                .Where(pe => pe.ProjectId == id)
                .ToList();
            var statuses = _context.Statuses.ToList();

            var viewModel = new ProjectStatusesModel
            {
                Project = project,
                Statuses = statuses,
                ViewName = "Update"
            };

            return View("ProjectForm", viewModel);
        }
    }
}
