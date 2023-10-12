// <copyright file="IAggregateRoot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MediatR;

namespace Core.Domain.Common
{
    /// <summary>
    /// An interface that designates an object that may compose other minor objects.
    /// </summary>
    public interface IAggregateRoot
    {
        /// <summary>
        /// Gets a <see cref="IEnumerable{INotifciation}"/> from the current aggregate root instance operation.
        /// </summary>
        IEnumerable<INotification> Notifications { get; }
    }
}
