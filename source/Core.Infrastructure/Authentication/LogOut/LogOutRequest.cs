// <copyright file="LogOutRequest.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Domain.Customers;
using MediatorBuddy;

namespace Core.Infrastructure.Authentication.LogOut
{
    /// <summary>
    /// A request to trigger an Auth logOut.
    /// </summary>
    public class LogOutRequest : IEnvelopeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogOutRequest"/> class.
        /// </summary>
        /// <param name="userName">The userName of the <see cref="Customer"/> to logOut.</param>
        [JsonConstructor]
        public LogOutRequest(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// Gets the UserName of the <see cref="Customer"/> to logOut.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; }
    }
}
