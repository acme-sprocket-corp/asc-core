// <copyright file="ObjectVerification.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Core.API.Common
{
    /// <summary>
    /// Validator for API requests.
    /// </summary>
    public static class ObjectVerification
    {
        /// <summary>
        /// Validates a request object against its attributes.
        /// </summary>
        /// <param name="entity">The object being validated.</param>
        /// <returns>An <see cref="ObjectVerificationResult"/> instance.</returns>
        public static ObjectVerificationResult Validate(object entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return ObjectVerificationResult.Failure(results.Select(validationResult => validationResult.ErrorMessage ?? string.Empty));
            }

            return ObjectVerificationResult.Successful();
        }
    }
}
