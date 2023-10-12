// <copyright file="LogOutRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Application.Common.Responses;
using Core.Domain.Customers;

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
