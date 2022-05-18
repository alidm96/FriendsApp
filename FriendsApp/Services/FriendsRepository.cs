using FriendsApp.Data;
using FriendsApp.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace FriendsApp.Services
{
    public class FriendsRepository : IFriendsRepository
    {
        FriendsDbContext dbContext;
        public FriendsRepository(FriendsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Friend> Read()
        {
            return this.dbContext.Friends.ToList();
        }
        public void Create(Friend friend)
        {
            this.dbContext.Friends.Add(friend);

            Save();
        }
        public void Update(Friend friend)
        {
            this.dbContext.Friends.Update(friend);

            Save();
        }
        public void Delete(int id)
        {
            Friend friend = this.dbContext.Friends.Find(id);
            this.dbContext.Friends.Remove(friend);

            Save();
        }
        private void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
