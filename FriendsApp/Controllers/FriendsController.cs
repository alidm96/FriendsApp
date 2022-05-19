using FriendsApp.Data;
using FriendsApp.Data.Context;
using FriendsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace FriendsApp.Controllers
{
    public class FriendsController : Controller
    {
        public static int FriendsCount;
        public static string FriendsJSON;

        IFriendsService fs;
        public FriendsController(IFriendsService service)
        {
            fs = service;
        }

        public IActionResult Index()
        {
            FriendsCount = fs.GetFriendsList().Count();
            FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View();
        }

        public IActionResult List(Friend friend)
        {
            if (this.ModelState.IsValid && friend.Name != null)
            {
                fs.AddFriend(friend);
            }
            if (fs.GetFriendsList().Count == 0)
            {
                fs.FirstAdd();
            }
            var friends = fs.GetFriendsList();
            FriendsCount = fs.GetFriendsList().Count();
            FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View(friends);
        }
        public IActionResult detail(int Id)
        {
            var friends = fs.GetFriendsList();
            var friend = friends.Where(x => x.FriendId == Id).FirstOrDefault();
            FriendsCount = fs.GetFriendsList().Count();
            FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View(friend);
        }

        public IActionResult AddFriend()
        {
            FriendsCount = fs.GetFriendsList().Count();
            FriendsJSON = JsonConvert.SerializeObject(fs.GetFriendsList(), Formatting.Indented);

            return View();
        }
    }
}
