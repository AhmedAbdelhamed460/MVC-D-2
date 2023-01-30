using Microsoft.AspNetCore.Mvc;
using MVC_D_2.Models;
using MVC_D_2.ModelView;
using System.Collections.Generic;

namespace MVC_D_2.Controllers
{
    public class ProjectController : Controller
    {
         CompanyDBContext DB;
        public ProjectController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = DB.Projects.ToList();
            return View(projects);
        }
        [HttpGet]
        public IActionResult add()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(Projectmodelview projectmodelview)
        {
            if(ModelState.IsValid)
            {
                Project newproject = new Project()
                {

                    Name = projectmodelview.Name,
                    Location= projectmodelview.Location,
                };
                DB.Projects.Add(newproject);
                DB.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
