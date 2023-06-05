using System;
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
    }
}