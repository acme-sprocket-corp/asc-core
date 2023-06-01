using Core.Domain.Common.Clock;
using Core.Domain.Customers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Infrastructure.Authentication.LogOut
{
    internal class LogOutRequestHandler : IRequestHandler<LogOutRequest, LogOutResponse>
    {
        private readonly IClock _clock;
        private readonly UserManager<Customer> _userManager;

        public LogOutRequestHandler(IClock clock, UserManager<Customer> userManager)
        {
            _clock = clock;
            _userManager = userManager;
        }

        public async Task<LogOutResponse> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            var customer = await _userManager.FindByNameAsync(request.UserName);

            if (customer == null)
            {
                return LogOutResponse.UserNotFound();
            }

            customer.ResetRefreshToken(_clock);

            await _userManager.UpdateAsync(customer);

            return LogOutResponse.Success();
        }
    }
}
