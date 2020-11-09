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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAppHub _appHub;

        public EmployeesController(ApplicationDbContext context, IMapper mapper, IAppHub appHub)
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
        public async Task<IActionResult> UpdateAsync(Employee employee)
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

            await _appHub.Refresh();

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
