using FriendsApp.Data;
using FriendsApp.Data.Context;
using FriendsApp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var friends = await fs.GetFriendsList();
            FriendsCount = friends.Count;
            FriendsJSON = JsonConvert.SerializeObject(friends, Formatting.Indented);

            return View();
        }

        public async Task<IActionResult> List(Friend friend)
        {
            var friends = await fs.GetFriendsList();
            FriendsCount = friends.Count();

            if (this.ModelState.IsValid && friend.Name != null)
            {
                fs.AddFriend(friend);
            }
            if (FriendsCount == 0)
            {
                fs.FirstAdd();
            }
            friends = await fs.GetFriendsList();
            FriendsCount = friends.Count();
            FriendsJSON = JsonConvert.SerializeObject(friends, Formatting.Indented);

            return View(friends);
        }
        public async Task<IActionResult> detail(int Id)
        {
            var friends = await fs.GetFriendsList();
            var friend = friends.Where(x => x.FriendId == Id).FirstOrDefault();
            FriendsCount = friends.Count();
            FriendsJSON = JsonConvert.SerializeObject(friends, Formatting.Indented);

            return View(friend);
        }

        public async Task<IActionResult> AddFriend()
        {
            var friends = await fs.GetFriendsList();
            FriendsCount = friends.Count();
            FriendsJSON = JsonConvert.SerializeObject(friends, Formatting.Indented);

            return View();
        }
    }
}
