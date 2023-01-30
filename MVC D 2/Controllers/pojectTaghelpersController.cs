using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Day2TaskCompany.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day2TaskCompany.Controllers
{
    public class pojectTaghelpersController : Controller
    {
        private CompanyDBContext DB;
        public pojectTaghelpersController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllProjects()
        {
            List<Project> projects = DB.Projects.Include(p => p.Department).ToList();
            return View(projects);
        }

        public IActionResult Add()
        {
            List<Department> departments = DB.Departments.ToList();
            ViewBag.depts = new SelectList(departments, "Number", "Name");

            return View();
        }

        public IActionResult AddDb(Project project)
        {

            DB.Projects.Add(project);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllProjects));
        }

        public IActionResult Edit(int id)
        {
            Project project = DB.Projects.Include(p => p.Department).SingleOrDefault(p => p.Number == id);

            List<Department> departments = DB.Departments.ToList();
            ViewBag.depts = new SelectList(departments, "Number", "Name");

            return View(project);
        }
        //public IActionResult EditDb(Project projectToEdite)
        //{
          
        //        DB.Projects.Update(projectToEdite);
        //        DB.SaveChanges();
        //        return RedirectToAction(nameof(GetAllProjects));
           
        //}
        public IActionResult EditDb(Project projectToEdite)
        {
            Project oldProject = DB.Projects.SingleOrDefault(p => p.Number == projectToEdite.Number);
            if (oldProject == null)
            {
                return View("Error");
            }
            else
            {
                oldProject.Name = projectToEdite.Name;
                oldProject.Location = projectToEdite.Location;
                oldProject.DeptNum = projectToEdite.DeptNum;

                DB.SaveChanges();
                return RedirectToAction(nameof(GetAllProjects));
            }
        }

        public IActionResult Delete(int id)
        {
            Project Project = DB.Projects.SingleOrDefault(p => p.Number == id);

            DB.Projects.Remove(Project);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllProjects));
        }
    }
}
