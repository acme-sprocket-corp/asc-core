// <copyright file="IEnvelope.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Core.Application.Common.Responses
{
    /// <summary>
    /// Interface for an Envelope response wrapper.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public interface IEnvelope<out TResponse>
    {
        /// <summary>
        /// Gets the response object.
        /// </summary>
        public TResponse Response { get; }

        /// <summary>
        /// Gets the status of the operation.
        /// </summary>
        public ApplicationStatus Status { get; }

        /// <summary>
        /// Gets the error details for the operation.
        /// </summary>
        public string Detail { get; }
    }
}
