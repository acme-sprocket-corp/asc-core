// <copyright file="LogOutRequestHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Application.Customers.Common;
using Core.Domain.Common.Clock;
using MediatorBuddy;
using MediatR;

namespace Core.Infrastructure.Authentication.LogOut
{
    /// <summary>
    /// A handler for <see cref="LogOutRequest"/> that returns an empty response.
    /// </summary>
    public class LogOutRequestHandler : EnvelopeHandler<LogOutRequest>
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

        /// <inheritdoc />
        public override async Task<IEnvelope<Unit>> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.FindCustomerByName(request.UserName);

            if (customer == null)
            {
                return EntityWasNotFound();
            }

            customer.ResetRefreshToken(_clock);

            var result = await _customerRepository.UpdateCustomer(customer);

            if (result.Succeeded)
            {
                return Success();
            }

            return OperationCouldNotBeCompleted();
        }
    }
}
