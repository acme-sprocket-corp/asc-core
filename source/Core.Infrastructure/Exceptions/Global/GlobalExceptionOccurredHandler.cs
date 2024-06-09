// <copyright file="GlobalExceptionOccurredHandler.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using MediatorBuddy;
using MediatR;

namespace Core.Infrastructure.Exceptions.Global
{
    /// <inheritdoc />
    public class GlobalExceptionOccurredHandler : INotificationHandler<GlobalExceptionOccurred>
    {
        /// <inheritdoc/>
        public Task Handle(GlobalExceptionOccurred notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
