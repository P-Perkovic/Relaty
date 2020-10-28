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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            var titles = _context.Titles.ToList();
            var viewModel = new EmployeeTitlesModel
            {
                Employee = new Employee(),
                Titles = titles
            };

            return View(viewModel);
        }
    }
}
