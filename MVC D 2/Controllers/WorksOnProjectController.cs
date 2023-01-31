using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Day2TaskCompany.Models;
using MVC_D_2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public IActionResult EditEmployeeHour()
    {
        List<Employee> employees = DB.Employees.ToList();
        ViewBag.employees = new SelectList(employees, "SSN", "Fname");
        return View();
    }

    public IActionResult EditEmployeeHour_emp(int id)
    {
        List<Project>? projects = DB.WorksOnProjects.Include(wop => wop.Project).Where(wop => wop.EmpSSN == id).Select(wop => wop.Project).ToList();
        ViewBag.projects = new SelectList(projects, "Number", "Name");
        if (projects.Count > 0)
        {
            WorksOnProject worksOnProject = new WorksOnProject()
            {
                Hours = DB.WorksOnProjects.SingleOrDefault(wop => (wop.EmpSSN == id) && (wop.projNum == projects[0].Number)).Hours
            };
            return PartialView("_ProjectsList", worksOnProject);
        }
        return PartialView("_ProjectsList");
    }

    public IActionResult EditEmployeeHour_emp_proj(int id, int projNum)
    {
        WorksOnProject? worksOnProject = DB.WorksOnProjects.SingleOrDefault(wop => wop.EmpSSN == id && wop.projNum == projNum);
        //if (worksOnProject == null) return View("Error");
        return PartialView("_hour", worksOnProject);
    }

    public IActionResult EditEmployeeHourDb(WorksOnProject worksOnProject)
    {
        DB.WorksOnProjects.Update(worksOnProject);
        DB.SaveChanges();
        return View();
    }

}
