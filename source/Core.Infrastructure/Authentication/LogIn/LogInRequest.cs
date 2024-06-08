// <copyright file="LogInRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Application.Common.Responses;

namespace Core.Infrastructure.Authentication.LogIn
{
    /// <summary>
    /// Request object to start a user logIn operation.
    /// </summary>
    public class LogInRequest : IEnvelopeRequest<LogInResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogInRequest"/> class.
        /// </summary>
        /// <param name="userName">The userName for the user.</param>
        /// <param name="password">The password for the user.</param>
        [JsonConstructor]
        public LogInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Gets the UserName attempting to logIn.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }

        /// <summary>
        /// Gets the Password for the UserName attempting to logIn.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }
    }
}
