using System.Security.Claims;
using Core.Application.Common.Responses;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using Core.Infrastructure.Authentication.Tokens;

namespace Core.Infrastructure.Authentication.LogIn
{
    /// <summary>
    /// A handler for <see cref="LogInRequest"/> that returns a <see cref="LogInResponse"/>.
    /// </summary>
    public class LogInRequestHandler : IEnvelopeHandler<LogInRequest, LogInResponse>
    {
        private readonly IClock _clock;
        private readonly ITokenService _tokenService;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogInRequestHandler"/> class.
        /// </summary>
        /// <param name="clock">An instance of the <see cref="IClock"/> interface.</param>
        /// <param name="tokenService">An instance of the <see cref="ITokenService"/> interface.</param>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface.</param>
        public LogInRequestHandler(IClock clock, ITokenService tokenService, ICustomerRepository customerRepository)
        {
            _clock = clock;
            _tokenService = tokenService;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// The handler method for the <see cref="LogInRequest"/> object.
        /// </summary>
        /// <param name="request">An instance of type <see cref="LogInRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to prematurely end the operation.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="LogInResponse"/> that represents the operation.</returns>
        public async Task<IEnvelope<LogInResponse>> Handle(LogInRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindCustomerByName(request.UserName);

            if (customer == null)
            {
                return Envelope<LogInResponse>.Failure(ApplicationStatus.AuthenticationError, "UserName does not exist.");
            }

            var isPasswordCorrect = await _customerRepository.CheckCustomerPassword(customer, request.Password);

            if (!isPasswordCorrect)
            {
                return Envelope<LogInResponse>.Failure(ApplicationStatus.AuthenticationError, "Password is incorrect");
            }

            var claims = new List<Claim>
            {
                new Claim("UserName", customer.UserName),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);

            var refreshToken = _tokenService.GenerateRefreshToken();

            customer.UpdateRefreshToken(refreshToken, _clock);

            await _customerRepository.UpdateCustomer(customer);

            return Envelope<LogInResponse>.Success(new LogInResponse(accessToken, refreshToken));
        }
    }
}
