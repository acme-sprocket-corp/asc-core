using Core.Application.Common.Responses;

namespace Core.Infrastructure.Authentication.LogOut
{
    public class LogOutResponse : ApplicationResponse
    {
        private LogOutResponse()
        {
        }

        private LogOutResponse(Status status, string errorMessage)
            : base(status, errorMessage)
        {
        }

        public static LogOutResponse UserNotFound()
        {
            return new LogOutResponse(Status.AuthenticationError, "UserName does not exist.");
        }

        public static LogOutResponse Success()
        {
            return new LogOutResponse();
        }
    }
}
