using FriendsApp.Data;
using FriendsApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApp.Services
{
    public class FriendsRepository : IFriendsRepository
    {
        FriendsDbContext dbContext;
        public FriendsRepository(FriendsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Friend>> Read()
        {
            return await this.dbContext.Friends.ToListAsync();
        }
        public async void Create(Friend friend)
        {
            await this.dbContext.Friends.AddAsync(friend);

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
        private async void Save()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
