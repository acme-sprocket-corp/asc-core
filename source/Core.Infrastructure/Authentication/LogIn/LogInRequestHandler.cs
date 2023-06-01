using System.Security.Claims;
using Core.Application.Common.Responses;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using Core.Domain.Customers;
using Core.Infrastructure.Authentication.Tokens;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Authentication.LogIn
{
    internal class LogInRequestHandler : IRequestHandler<LogInRequest, LogInResponse>
    {
        private readonly IClock _clock;
        private readonly ITokenService _tokenService;
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<Customer> _userManager;

        public LogInRequestHandler(IClock clock, ITokenService tokenService, ICustomerRepository customerRepository, UserManager<Customer> userManager)
        {
            _clock = clock;
            _tokenService = tokenService;
            _customerRepository = customerRepository;
            _userManager = userManager;
        }

        public async Task<LogInResponse> Handle(LogInRequest request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByNameAsync(request.UserName);

            if (customer == null)
            {
                return new LogInResponse(Status.AuthenticationError, "UserName does not exist.");
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(customer, request.Password);

            if (!isPasswordCorrect)
            {
                return new LogInResponse(Status.AuthenticationError, "Password is incorrect");
            }

            var claims = new List<Claim>
            {
                new Claim("UserName", customer.UserName),
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);

            var refreshToken = _tokenService.GenerateRefreshToken();

            customer.UpdateRefreshToken(refreshToken, _clock);

            await _customerRepository.UpdateCustomer(customer);

            return new LogInResponse(accessToken, refreshToken);
        }
    }
}
