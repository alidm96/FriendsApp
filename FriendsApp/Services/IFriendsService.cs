using FriendsApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsApp.Services
{
    public interface IFriendsService
    {
        void AddFriend(Friend friend);
        Task<List<Friend>> GetFriendsList();
        void FirstAdd();
    }
}