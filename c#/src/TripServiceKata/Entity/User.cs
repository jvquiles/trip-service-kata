using System.Collections.Generic;
using System.Linq;

namespace TripServiceKata.Entity
{
    public class User
    {
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        }

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public bool AmIFriendOf(User user)
        {
            return user.GetFriends().Any(friend => friend.Equals(this));
        }
    }
}