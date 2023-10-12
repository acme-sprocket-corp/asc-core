// <copyright file="GlobalExceptionOccurred.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MediatR;

namespace Core.Infrastructure.Exceptions.GlobalExceptionHandler
{
    /// <summary>
    /// Raised when the application global exception handler is raised.
    /// </summary>
    public class GlobalExceptionOccurred : INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionOccurred"/> class.
        /// </summary>
        /// <param name="exception">The global exception raised.</param>
        public GlobalExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the global exception that occurred.
        /// </summary>
        public Exception Exception { get; }
    }
}
