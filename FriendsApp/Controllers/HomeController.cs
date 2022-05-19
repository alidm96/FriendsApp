using FriendsApp.Models;
using FriendsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IFriendsService fs;
        public HomeController(ILogger<HomeController> logger, IFriendsService service)
        {
            _logger = logger;
            fs = service;
        }

        public IActionResult Index()
        {
            FriendsApp.Controllers.FriendsController.FriendsCount = fs.GetFriendsList().Count;
            FriendsApp.Controllers.FriendsController.FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View();
        }

        public IActionResult Privacy()
        {
            FriendsApp.Controllers.FriendsController.FriendsCount = fs.GetFriendsList().Count;
            FriendsApp.Controllers.FriendsController.FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
