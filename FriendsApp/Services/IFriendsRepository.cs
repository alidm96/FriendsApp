using FriendsApp.Data;
using System.Collections.Generic;

namespace FriendsApp.Services
{
    public interface IFriendsRepository
    {
        void Create(Friend friend);
        void Delete(int id);
        List<Friend> Read();
        void Update(Friend friend);
    }
}