using Microsoft.AspNetCore.Mvc;

namespace JustCook.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
