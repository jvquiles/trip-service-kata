using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Service
{
    public interface ITripDAO
    {
        List<Trip> FindTripsByUser(User user);
    }

    public class TripDAO : ITripDAO
    {
        public List<Trip> FindTripsByUser(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "TripDAO should not be invoked on an unit test.");
        }
    }
}