using Microsoft.AspNetCore.Mvc;

namespace MVC_D_2.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
