using Microsoft.AspNetCore.Mvc;

namespace FriendsApp.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
