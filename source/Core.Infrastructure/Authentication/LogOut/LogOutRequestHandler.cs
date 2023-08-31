using Core.Application.Common.Responses;
using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using MediatR;

namespace Core.Infrastructure.Authentication.LogOut
{
    /// <summary>
    /// A handler for <see cref="LogOutRequest"/> that returns an empty response..
    /// </summary>
    public class LogOutRequestHandler : IEnvelopeHandler<LogOutRequest>
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
        /// <returns>A <see cref="Task"/> of type <see cref="IEnvelope{Unit}"/> that represents the operation.</returns>
        public async Task<IEnvelope<Unit>> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindCustomerByName(request.UserName);

            if (customer == null)
            {
                return Envelope<Unit>.Failure(ApplicationStatus.AuthenticationError);
            }

            customer.ResetRefreshToken(_clock);

            var result = await _customerRepository.UpdateCustomer(customer);

            if (result.Succeeded)
            {
                return Envelope<Unit>.Success(Unit.Value);
            }

            return Envelope<Unit>.Failure(ApplicationStatus.AuthenticationError);
        }
    }
}
