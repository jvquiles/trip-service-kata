using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserSession _userSession;
        private readonly ITripDAO _tripDao;

        public TripService(IUserSession userSession, ITripDAO tripDao)
        {
            _userSession = userSession;
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            var tripList = new List<Trip>();
            var loggedUser = _userSession.GetLoggedUser();
            if (loggedUser != null)
            {
                if (loggedUser.AmIFriendOf(user))
                {
                    tripList = _tripDao.FindTripsByUser(user);
                }

                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}