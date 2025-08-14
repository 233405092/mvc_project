using Microsoft.AspNetCore.Mvc;
namespace mvc_project.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
