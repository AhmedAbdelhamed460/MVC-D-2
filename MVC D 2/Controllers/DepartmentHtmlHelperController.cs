using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Day2TaskCompany.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day2TaskCompany.Controllers
{
    public class DepartmentHtmlHelperController : Controller
    {
        private CompanyDBContext DB;
        public DepartmentHtmlHelperController()
        {
            DB = new CompanyDBContext();

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllDepartments()
        {
            List<Department> departments = DB.Departments.Include(d=>d.DepartmentLocations).ToList();
            return View(departments);
        }

        public IActionResult GetDepartmentById(int id)
        {
            Department department = DB.Departments.Include(d => d.DepartmentLocations).Include(d=> d.Projects).Include(d=>d.employeeManege).SingleOrDefault(d=> d.Number == id);
            if (department == null)
                return View("Error");
            else
                return View(department);
        }
        public IActionResult Add()
        {
            List<Employee> employees = DB.Employees.ToList();
            ViewBag.emps = new SelectList(employees, "SSN", "Fname");

            return View();
        }

        public IActionResult AddDb(Department department)
        {

            DB.Departments.Add(department);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDepartments));
        }

        public IActionResult Edit(int id)
        {
            Department department = DB.Departments.Include(d=> d.DepartmentLocations).SingleOrDefault(d => d.Number == id);
            List<Employee> employees = DB.Employees.ToList();
            ViewBag.emps = new SelectList(employees, "SSN", "Fname");


            return View(department);
        }

        public IActionResult EditDb(Department departmentToEdit)
        {
            
            DB.Departments.Update(departmentToEdit);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDepartments));
        }

        public IActionResult Delete(int id)
        {
            Department department = DB.Departments.SingleOrDefault(d => d.Number == id);

            DB.Departments.Remove(department);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDepartments));
        }


    }
}
