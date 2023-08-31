﻿using System.ComponentModel.DataAnnotations;
using Core.Application.Common.Responses;

namespace Core.Application.Customers.AddCustomer
{
    public class AddCustomerResponse : ApplicationResponse
    {
        public AddCustomerResponse(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public AddCustomerResponse(ApplicationStatus applicationStatus, string errorMessage)
            : base(applicationStatus, errorMessage)
        {
            UserName = string.Empty;
            Email = string.Empty;
        }

        [Required]
        public string UserName { get; }

        [Required]
        public string Email { get; }
    }
}
