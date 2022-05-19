using FriendsApp.Data;
using System.Collections.Generic;

namespace FriendsApp.Services
{
    public interface IFriendsService
    {
        void AddFriend(Friend friend);
        List<Friend> GetFriendsList();
        void FirstAdd();
    }
}