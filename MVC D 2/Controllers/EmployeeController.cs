
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MVC_D_2.Models;

namespace MVC_D_2.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyDBContext DB;
        public EmployeeController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = DB.Employees.ToList();
            return View("Index", employees);
        }

        public IActionResult GetById(int id)
        {

            Employee? employee = DB.Employees.Include(s => s.Supervisor).Where(e => e.SSN == id).SingleOrDefault();
            ; if (employee == null)
                return View("Error");
            else
                return View(employee);
        }

        public IActionResult Add()
        {
            List<Employee> employees = DB.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddEmployeeDb(Employee employee)
        {
            DB.Employees.Add(employee);
            DB.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            List<Employee> employees = DB.Employees.ToList();
            Employee? employee = DB.Employees.Include(s => s.Supervisor).Where(e => e.SSN == id).SingleOrDefault();
            ViewBag.emp = employees;
            if (employee == null)
                return View("Error");
            else
                return View(employee);

        }



    }
}