// <copyright file="AddCustomerHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Application.Customers.Common;
using Core.Domain.Customers;
using MediatorBuddy;

namespace Core.Application.Customers.AddCustomer
{
    /// <summary>
    /// A handler for <see cref="AddCustomerRequest"/> that returns a <see cref="AddCustomerResponse"/>.
    /// </summary>
    public class AddCustomerHandler : EnvelopeHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCustomerHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">An instance of the <see cref="ICustomerRepository"/> interface.</param>
        public AddCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// The handler method for the <see cref="AddCustomerRequest"/> object.
        /// </summary>
        /// <param name="request">An instance of type <see cref="AddCustomerRequest"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to prematurely end the operation.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="AddCustomerResponse"/> that represents the operation.</returns>
        public override async Task<IEnvelope<AddCustomerResponse>> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var passwordValidator = new PasswordValidator();

            var validationResult = await passwordValidator.ValidateAsync(request.Password, cancellationToken);

            if (!validationResult.IsValid)
            {
                return GeneralAuthError(validationResult.Errors.First().ErrorMessage);
            }

            var customer = CustomerFactory.CreateCustomer(request);

            var result = await _customerRepository.AddCustomer(customer, request.Password);

            return CustomerFactory.CreateCustomerResponse(result, customer);
        }
    }
}
