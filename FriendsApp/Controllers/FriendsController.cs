using FriendsApp.Data;
using FriendsApp.Data.Context;
using FriendsApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FriendsApp.Controllers
{
    public class FriendsController : Controller
    {
        IFriendsService fs;
        public FriendsController(IFriendsService service)
        {
            fs = service;
        }

        public IActionResult Index()
        {
            var friends = fs.GetFriendsList();

            return View(friends);
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

            return View(friends);
        }
        public IActionResult detail(int Id)
        {
            var friends = fs.GetFriendsList();
            var friend = friends.Where(x => x.FriendId == Id).FirstOrDefault();

            return View(friend);
        }

        public IActionResult AddFriend()
        {
            return View();
        }
    }
}
