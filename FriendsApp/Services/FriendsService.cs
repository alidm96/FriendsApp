using FriendsApp.Data;
using System.Collections.Generic;

namespace FriendsApp.Services
{
    public class FriendsService : IFriendsService
    {
        IFriendsRepository fr;
        public FriendsService(IFriendsRepository fr)
        {
            this.fr = fr;
        }

        public List<Friend> GetFriendsList()
        {
            return this.fr.Read();
        }

        public void AddFriend(Friend friend)
        {
            this.fr.Create(friend);
        }

        public void FirstAdd()
        {
            this.fr.Create(new Friend()
            {
                Name = "Mohammad",
                FriendId = 1,
                Image = "/images/1.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Hassan",
                FriendId = 2,
                Image = "/images/2.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Zahra",
                FriendId = 3,
                Image = "/images/3.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Somayeh",
                FriendId = 4,
                Image = "/images/4.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Shima",
                FriendId = 5,
                Image = "/images/5.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Ramin",
                FriendId = 6,
                Image = "/images/6.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Hamid",
                FriendId = 7,
                Image = "/images/7.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Sima",
                FriendId = 8,
                Image = "/images/8.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Farshad",
                FriendId = 9,
                Image = "/images/9.jpg"
            });

            this.fr.Create(new Friend()
            {
                Name = "Jamshid",
                FriendId = 10,
                Image = "/images/10.jpg"
            });
        }
    }
}
