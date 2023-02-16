using Core.Application.Customers.Common;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    internal class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly CustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerHandler(CustomerFactory customerFactory, ICustomerRepository customerRepository)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
        }

        public async Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = _customerFactory.CreateCustomer(request);

            var result = await _customerRepository.AddCustomer(customer, request.Password);

            return _customerFactory.CreateCustomerResponse(result, customer);
        }
    }
}
