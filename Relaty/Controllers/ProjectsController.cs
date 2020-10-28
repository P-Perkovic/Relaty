using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Models;
using Relaty.ViewModels;

namespace Relaty.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
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
                Statuses = statuses
            };

            return View(viewModel);
        }
    }
}
