using Core.Application.Customers.AddCustomer;
using Core.Tests.Integration.Common;
using MediatorBuddy;

namespace Core.Tests.Integration.Customers
{
    [TestClass]
    public class AddCustomerHandlerTests
    {
        public AddCustomerHandlerTests()
        {
            DependencyHelpers.ClearDatabase();
        }

        [TestMethod]
        public async Task AddCustomerHandler_ProperlyAddsNewCustomer()
        {
            var request = new AddCustomerRequest("mjbrad", "mjbrad@brad.com", "Password123!");

            var handler = DependencyHelpers.GetHandler<AddCustomerRequest, AddCustomerResponse>();

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(ApplicationStatus.Success, result.Status);
        }
    }
}
