using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Day2TaskCompany.Models;

namespace Day2TaskCompany.Controllers
{
    public class WorksOnProjectController : Controller
    {
        private CompanyDBContext DB;
        public WorksOnProjectController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployeesToProjects(int id)
        {
            List<Project> projects = DB.Projects.Where(p => p.DeptNum == id).ToList();
            List<Employee> employees = DB.Employees.Where(p => p.deptId == id).ToList();

            ViewBag.emps = employees;
            ViewBag.deptNum = id;
            return View(projects);
        }

        WorksOnProject worksOnProject1;
        public IActionResult AddEmployeesToProjectsToDB( List<int> Projects, List<int> Employees, int deptNum)
        {

            foreach (var Project in Projects)
            {
                foreach (var employee in Employees)
                {
                    WorksOnProject worksOnProject = new WorksOnProject()
                    {
                        EmpSSN = employee,
                        projNum = Project
                    };
                    //worksOnProject1 = DB.WorksOnProjects.Include(wop => wop.Project).SingleOrDefault(wop => wop.EmpSSN == worksOnProject.EmpSSN);
                    DB.WorksOnProjects.Add(worksOnProject);
                    DB.SaveChanges();
                }
                   
            }

            
            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View(deptNum);
        }
       
    }
}
