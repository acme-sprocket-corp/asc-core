using Core.Application.Common.Responses;
using MediatR;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, Envelope<string>>
    {
        public Task<Envelope<string>> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
