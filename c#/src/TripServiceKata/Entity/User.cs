using System.Collections.Generic;

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
            foreach (var friend in user.GetFriends())
            {
                if (friend.Equals(this))
                {
                    return true;
                    break;
                }
            }

            return false;
        }
    }
}