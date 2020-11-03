using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relaty.Data;
using Relaty.Models;
using Relaty.ViewModels;

namespace Relaty.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
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
            var titles = _context.Titles.ToList();
            var viewModel = new EmployeeTitlesModel
            {
                Employee = new Employee(),
                Titles = titles
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid == false){
                var titles = _context.Titles.ToList();
                var viewModel = new EmployeeTitlesModel
                {
                    Employee = employee,
                    Titles = titles
                };

                return View("New", viewModel);
            }

            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
