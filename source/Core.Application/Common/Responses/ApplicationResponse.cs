using System.Text.Json.Serialization;

namespace Core.Application.Common.Responses
{
    public abstract class ApplicationResponse
    {
        protected ApplicationResponse()
        {
            Status = Status.Success;
            ErrorMessage = string.Empty;
        }

        protected ApplicationResponse(Status status, string errorMessage)
        {
            Status = status;
            ErrorMessage = errorMessage;
        }

        [JsonIgnore]
        public Status Status { get; }

        [JsonIgnore]
        public string ErrorMessage { get; }
    }
}
