// <copyright file="SystemClock.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using Core.Domain.Common.Clock;

namespace Core.Infrastructure.Clock
{
    /// <inheritdoc />
    public class SystemClock : IClock
    {
        /// <inheritdoc/>
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
