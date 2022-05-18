using Microsoft.EntityFrameworkCore;

namespace FriendsApp.Data.Context
{
    public class FriendsDbContext : DbContext
    {
        public FriendsDbContext(DbContextOptions<FriendsDbContext> options)
            : base(options)
        {

        }

        DbSet<Friend> Friends { get; set; }
    }
}
