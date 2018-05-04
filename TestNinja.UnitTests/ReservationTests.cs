using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ShouldReturnTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAdmin_ShouldReturnFalse()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_ReservationMadeBySameUser_ShouldReturnTrue()
        {
            // Arrange
            var reservation = new Reservation();
            var user = new User();
            user.IsAdmin = false;
            reservation.MadeBy = user;

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_ReservationMadeByDifferentUser_ShouldReturnFalse()
        {
            // Arrange
            var reservation = new Reservation();
            var user = new User();
            user.IsAdmin = false;
            reservation.MadeBy = user;

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false });

            // Assert
            Assert.IsFalse(result);
        }
    }
}
