using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void FailWhenThereIsNoLoggedUser()
        {
            var userSession = Substitute.For<IUserSession>();
            var tripDao = Substitute.For<ITripDAO>();
            var tripService = new TripService(userSession, tripDao);
            var user = new User();

            var action = new Action(() => tripService.GetTripsByUser(user));

            action.Should().Throw<UserNotLoggedInException>();
        }

        [Fact]
        public void GetNoTripsWhenUserHasNoFriends()
        {
            var userSession = Substitute.For<IUserSession>();
            var user = new User();
            userSession.GetLoggedUser().Returns(user);
            var tripDao = Substitute.For<ITripDAO>();
            var tripService = new TripService(userSession, tripDao);

            var trips = tripService.GetTripsByUser(user);

            trips.Should().BeEmpty();
        }

        [Fact]
        public void GetOneFriendTrip()
        {
            var userSession = Substitute.For<IUserSession>();
            var user = new User();
            var friend = new User();
            user.AddFriend(friend);
            userSession.GetLoggedUser().Returns(friend);
            var tripDao = Substitute.For<ITripDAO>();
            var trip = new Trip();
            tripDao.FindTripsByUser(Arg.Any<User>()).Returns(new List<Trip>() { trip });
            var tripService = new TripService(userSession, tripDao);

            var expectedTrips = tripService.GetTripsByUser(user);

            expectedTrips.Should().ContainEquivalentOf(trip);
        }
    }
}