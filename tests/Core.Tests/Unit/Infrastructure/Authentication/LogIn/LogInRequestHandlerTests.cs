using Core.Application.Common.Responses;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using Core.Domain.Customers;
using Core.Infrastructure.Authentication.LogIn;
using Core.Infrastructure.Authentication.Tokens;
using Moq;

namespace Core.Tests.Unit.Infrastructure.Authentication.LogIn
{
    [TestClass]
    public class LogInRequestHandlerTests
    {
        private readonly Mock<IClock> _clock;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly LogInRequestHandler _handler;

        public LogInRequestHandlerTests()
        {
            _clock = new Mock<IClock>();
            _tokenService = new Mock<ITokenService>();
            _customerRepository = new Mock<ICustomerRepository>();
            _handler = new LogInRequestHandler(_clock.Object, _tokenService.Object, _customerRepository.Object);
        }

        [TestMethod]
        public async Task Handle_NullCustomer_ReturnsCorrectResponse()
        {
            _customerRepository.Setup(x => x.FindCustomerByName(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var result = await _handler.Handle(new LogInRequest(string.Empty, string.Empty), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.AuthenticationError, result.Status);
        }

        [TestMethod]
        public async Task Handle_IncorrectPassword_ReturnsCorrectResponse()
        {
            _customerRepository.Setup(x => x.FindCustomerByName(It.IsAny<string>()))
                .ReturnsAsync(new Customer(string.Empty, string.Empty));

            _customerRepository.Setup(x => x.CheckCustomerPassword(It.IsAny<Customer>(), It.IsAny<string>()))
                .ReturnsAsync(() => false);

            var result = await _handler.Handle(new LogInRequest(string.Empty, string.Empty), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.AuthenticationError, result.Status);
        }

        [TestMethod]
        public async Task Handle_ReturnsCorrectResponse()
        {
            _customerRepository.Setup(x => x.FindCustomerByName(It.IsAny<string>()))
                .ReturnsAsync(new Customer(string.Empty, string.Empty));

            _customerRepository.Setup(x => x.CheckCustomerPassword(It.IsAny<Customer>(), It.IsAny<string>()))
                .ReturnsAsync(() => true);

            var result = await _handler.Handle(new LogInRequest(string.Empty, string.Empty), CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.Success, result.Status);
        }
    }
}
