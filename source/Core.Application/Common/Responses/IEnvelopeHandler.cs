// <copyright file="IEnvelopeHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatR;

namespace Core.Application.Common.Responses
{
    /// <summary>
    /// Helper interface for envelope handlers.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <typeparam name="TResponse">The tye of the response object.</typeparam>
    public interface IEnvelopeHandler<in TRequest, TResponse> : IRequestHandler<TRequest, IEnvelope<TResponse>>
        where TRequest : IEnvelopeRequest<TResponse>
    {
    }

    /// <summary>
    /// Helper interface for void based envelope handlers.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    public interface IEnvelopeHandler<in TRequest> : IRequestHandler<TRequest, IEnvelope<Unit>>
        where TRequest : IEnvelopeRequest
    {
    }
}
