namespace Core.Application.Common.Responses
{
    public class Envelope<TResponse>
    {
        private Envelope(bool isSuccess, Status status, TResponse response)
        {
            IsSuccess = isSuccess;
            Status = status;
            Response = response;
        }

        public bool IsSuccess { get; }

        public Status Status { get; }

        public TResponse? Response { get; }

        public static Envelope<TResponse> Success(TResponse response)
        {
            return new Envelope<TResponse>(true, Status.Success, response);
        }

        public static Envelope<TResponse?> Failure(Status status)
        {
            return new Envelope<TResponse?>(false, status, default);
        }
    }
}
