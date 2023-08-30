using Core.Domain.Common.Clock;
using Core.Domain.Customers;
using Core.Tests.Common;
using Moq;

namespace Core.Tests.Unit.Domain.Customers
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void UserName_Initialized_ReturnsValue()
        {
            const string userName = "mikeBrad";

            var customer = new Customer(userName, "mjbrad@gmail.com");

            Assert.AreEqual(userName, customer.UserName);
        }

        [TestMethod]
        public void Email_Initialized_ReturnsValue()
        {
            const string email = "mjbrad@gmail.com";

            var customer = new Customer("mikeBrad", email);

            Assert.AreEqual(email, customer.Email);
        }

        [TestMethod]
        public void UpdateRefreshToken_HasCorrectProperties()
        {
            var customer = Utilities.ValidCustomer();

            const string token = "refreshToken";

            var clock = new Mock<IClock>();
            clock.Setup(instance => instance.UtcNow()).Returns(Utilities.YearTwoThousand());
            var expectedTime = Utilities.YearTwoThousand().AddMinutes(15);

            customer.UpdateRefreshToken(token, clock.Object);

            Assert.AreEqual(token, customer.RefreshToken);
            Assert.AreEqual(expectedTime, customer.RefreshTokenExpiration);
        }

        [TestMethod]
        public void ResetRefreshToken_HasCorrectProperties()
        {
            var customer = Utilities.ValidCustomer();

            var clock = new Mock<IClock>();
            clock.Setup(instance => instance.UtcNow()).Returns(Utilities.YearTwoThousand());

            customer.UpdateRefreshToken("refreshToken", clock.Object);

            customer.ResetRefreshToken(clock.Object);

            Assert.AreEqual(string.Empty, customer.RefreshToken);
            Assert.AreEqual(Utilities.YearTwoThousand(), customer.RefreshTokenExpiration);
        }
    }
}
