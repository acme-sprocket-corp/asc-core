using MediatR;

namespace Core.Application.Common.Responses
{
    /// <summary>
    /// Helper interface for void based envelope requests.
    /// </summary>
    public interface IEnvelopeRequest : IRequest<IEnvelope<Unit>>
    {
    }

    /// <summary>
    /// Helpers interface for envelope requests.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public interface IEnvelopeRequest<out TResponse> : IRequest<IEnvelope<TResponse>>
    {
    }
}
