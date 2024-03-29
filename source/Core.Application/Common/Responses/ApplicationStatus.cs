﻿// <copyright file="ApplicationStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Core.Application.Common.Responses
{
    /// <summary>
    /// Describes the current status of the application.
    /// </summary>
    public enum ApplicationStatus
    {
        /// <summary>
        /// Request succeeded.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Entity did not meet validation requirements.
        /// </summary>
        ValidationError = 1,

        /// <summary>
        /// Error along the Identity/Authentication pipeline.
        /// </summary>
        AuthenticationError = 2,
    }
}
