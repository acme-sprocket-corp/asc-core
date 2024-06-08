// <copyright file="PasswordRequirements.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Text.RegularExpressions;

namespace Core.Domain.Customers
{
    /// <summary>
    /// Requirements for <see cref="Customer"/> passwords.
    /// </summary>
    public class PasswordRequirements
    {
        /// <summary>
        /// Gets the minimum password length for a <see cref="Customer"/>.
        /// </summary>
        public const int MinimumPasswordLength = 8;

        /// <summary>
        /// Gets a string for <see cref="Regex"/> that must contain at least one lowercase, one uppercase, one number, and one special character.
        /// </summary>
        public const string PasswordRegex = "^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!#$%&? \"]).*$";
    }
}
