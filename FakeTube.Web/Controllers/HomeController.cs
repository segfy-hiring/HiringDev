using Microsoft.AspNetCore.Mvc;

namespace FakeTube.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(YoutubeController.Search), nameof(YoutubeController).Replace("Controller", ""));
        }
    }
}
