// <copyright file="AggregateRoot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MediatR;

namespace Core.Domain.Common
{
    /// <inheritdoc />
    public abstract class AggregateRoot : IAggregateRoot
    {
        private readonly List<INotification> _notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot"/> class.
        /// </summary>
        protected AggregateRoot()
        {
            _notifications = new List<INotification>();
        }

        /// <inheritdoc/>
        public IEnumerable<INotification> Notifications => _notifications.AsEnumerable();

        /// <summary>
        /// Adds an event to the <see cref="IAggregateRoot"/> collection.
        /// </summary>
        /// <param name="notification">An <see cref="INotification"/> to add to the event collection.</param>
        protected void AddNotification(INotification notification)
        {
            _notifications.Add(notification);
        }
    }
}
