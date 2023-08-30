using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using MediatR;

namespace Core.Infrastructure.Authentication.LogOut
{
    /// <summary>
    /// A handler for <see cref="LogOutRequest"/> that returns a <see cref="LogOutResponse"/>.
    /// </summary>
    public class LogOutRequestHandler : IRequestHandler<LogOutRequest, LogOutResponse>
    {
        private readonly IClock _clock;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogOutRequestHandler"/> class.
        /// </summary>
        /// <param name="clock">An instance of the <see cref="IClock"/> interface.</param>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface.</param>
        public LogOutRequestHandler(IClock clock, ICustomerRepository customerRepository)
        {
            _clock = clock;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// A handler for the <see cref="LogOutRequest"/>.
        /// </summary>
        /// <param name="request">An instance off type <see cref="LogOutRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to prematurely end the operation.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="LogOutResponse"/> that represents the operation.</returns>
        public async Task<LogOutResponse> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindCustomerByName(request.UserName);

            if (customer == null)
            {
                return LogOutResponse.UserNotFound();
            }

            customer.ResetRefreshToken(_clock);

            var result = await _customerRepository.UpdateCustomer(customer);

            return LogOutResponse.Success();
        }
    }
}
