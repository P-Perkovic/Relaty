using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Dtos;
using Relaty.Models;
using Relaty.ViewModels;

namespace Relaty.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {

            if(ModelState.IsValid == false)
            {
                var statuses = _context.Statuses.ToList();
                var viewModel = new ProjectStatusesModel
                {
                    Project = project,
                    Statuses = statuses
                };
                return View("New", viewModel);
            }

            _context.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
