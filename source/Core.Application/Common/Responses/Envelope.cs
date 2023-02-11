namespace Core.Application.Common.Responses
{
    public class Envelope<TResponse>
        where TResponse : new()
    {
    private Envelope(Status status, TResponse response, string errorMessage)
    {
        Status = status;
        Response = response;
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; }

    public Status Status { get; }

    public TResponse Response { get; }

    public static Envelope<TResponse> Success(TResponse response)
    {
        return new Envelope<TResponse>(Status.Success, response, string.Empty);
    }

    public static Envelope<TResponse> Failure(Status status, string errorMessage = "")
    {
        return new Envelope<TResponse>(status, new TResponse(), errorMessage);
    }
    }
}
