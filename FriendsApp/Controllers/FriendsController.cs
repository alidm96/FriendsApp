using FriendsApp.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FriendsApp.Controllers
{
    public class FriendsController : Controller
    {
        FriendsDbContext DbContext;
        public FriendsController(FriendsDbContext database)
        {
            DbContext = database;
        }

        public IActionResult Index()
        {
            var friends = DbContext.Friends.ToList();

            return View(friends);
        }
    }
}
