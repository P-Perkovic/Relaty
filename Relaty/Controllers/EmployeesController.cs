using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Relaty.Data;
using Relaty.Dtos;
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
                Titles = titles,
                ViewName = "New"
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid == false){
                var titles = _context.Titles.ToList();
                string viewName;
                if (employee.Id == 0)
                {
                    viewName = "New";
                }
                else
                {
                    viewName = "Update";
                }

                var viewModel = new EmployeeTitlesModel
                {
                    Employee = employee,
                    Titles = titles,
                    ViewName = viewName
                };

                return View("EmployeeForm", viewModel);
            }

            if(employee.Id == 0)
            {
                _context.Add(employee);
            }
            else
            {
                var emplyeeDb = _context.Employees.SingleOrDefault(e => e.Id == employee.Id);
                _mapper.Map(employee, emplyeeDb);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var employee = _context.Employees
                .Include(e => e.Title).
                SingleOrDefault(e => e.Id == id);
            employee.ProjectsEmployees = _context.ProjectsEmployees
                .Include(pe => pe.Project)
                .Where(pe => pe.EmployeeId == id)
                .ToList();
            var titles = _context.Titles.ToList();

            var viewModel = new EmployeeTitlesModel
            {
                Employee = employee,
                Titles = titles,
                ViewName = "Update"
            };

            return View("EmployeeForm", viewModel);
        }
    }
}
