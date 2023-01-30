using Microsoft.AspNetCore.Mvc;

namespace MVC_D_2.Controllers
{
    public class customvalidationController : Controller
    {
        public IActionResult validateproject( string Location)
        {
            if (Location.Contains("cairo")|| Location.Contains("alex") || Location.Contains("giza"))
            {
                return Json(true);
            }
            return Json(false);
               
            
        }
    }
}
