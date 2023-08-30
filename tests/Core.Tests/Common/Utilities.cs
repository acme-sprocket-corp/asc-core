using Core.Domain.Customers;

namespace Core.Tests.Common
{
    internal static class Utilities
    {
        public static DateTime YearTwoThousand()
        {
            return new DateTime(2000, 1, 1, 0, 0, 0);
        }

        public static Customer ValidCustomer()
        {
            return new Customer("mikeBrad", "mikeBrad@gmail.com");
        }
    }
}
