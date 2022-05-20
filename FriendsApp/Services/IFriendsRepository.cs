using FriendsApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsApp.Services
{
    public interface IFriendsRepository
    {
        void Create(Friend friend);
        void Delete(int id);
        Task<List<Friend>> Read();
        void Update(Friend friend);

        void UpperName();
    }
}