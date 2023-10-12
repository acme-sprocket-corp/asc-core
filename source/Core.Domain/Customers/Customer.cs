// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Core.Domain.Common.Clock;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Customers
{
    /// <summary>
    /// An object that represents a user with account properties.
    /// </summary>
    public sealed class Customer : IdentityUser<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="userName">An alphanumeric unique userName for the <see cref="Customer"/>.</param>
        /// <param name="email">A valid email address for the <see cref="Customer"/>.</param>
        public Customer(string userName, string email)
            : base(userName)
        {
            Email = email;
            RefreshToken = string.Empty;

            var validator = new CustomerValidator();
            validator.ValidateAndThrow(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class from persistence.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <param name="userName">The customer userName.</param>
        /// <param name="email">The customer email.</param>
        /// <param name="refreshToken">The refresh token for access.</param>
        /// <param name="refreshTokenExpiration">The refresh token expiration timestamp.</param>
        public Customer(Guid id, string userName, string email, string refreshToken, DateTime refreshTokenExpiration)
        {
            Id = id;
            UserName = userName;
            Email = email;
            RefreshToken = refreshToken;
            RefreshTokenExpiration = refreshTokenExpiration;
        }

        /// <summary>
        /// Gets a refresh token, a long lived token that allows a user to retrieve a new access token.
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Gets a timestamp for when a refresh token will be valid until.
        /// </summary>
        public DateTime RefreshTokenExpiration { get; private set; }

        /// <summary>
        /// Gets the base UserName implementation, and throws an exception on a null value.
        /// </summary>
        public override string UserName
        {
            get => base.UserName!;
        }

        /// <summary>
        /// Gets the base Email implementation, and throws an exception on a null value.
        /// </summary>
        public override string Email
        {
            get => base.Email!;
        }

        /// <summary>
        /// Updates the current <see cref="Customer"/> refresh token for 15 minutes.
        /// </summary>
        /// <param name="refreshToken">The new refreshToken for the <see cref="Customer"/>.</param>
        /// <param name="clock">An <see cref="IClock"/> instance to get the current timestamp.</param>
        public void UpdateRefreshToken(string refreshToken, IClock clock)
        {
            const int clockSkew = 15;

            RefreshToken = refreshToken;
            RefreshTokenExpiration = clock.UtcNow().AddMinutes(clockSkew);
        }

        /// <summary>
        /// Removes the current refreshToken. Occurs on User or forced logOut.
        /// </summary>
        /// <param name="clock">An instance of <see cref="IClock"/> to reset the token expiration.</param>
        public void ResetRefreshToken(IClock clock)
        {
            RefreshToken = string.Empty;
            RefreshTokenExpiration = clock.UtcNow();
        }
    }
}
