using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.UI.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
