// <copyright file="ObjectVerificationResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Core.API.Common
{
    /// <summary>
    /// Represents the status of a Validation result.
    /// </summary>
    public class ObjectVerificationResult
    {
        private ObjectVerificationResult(bool failed, IEnumerable<string> errors)
        {
            Failed = failed;
            Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the validation failed.
        /// </summary>
        public bool Failed { get; }

        /// <summary>
        /// Gets a list of any error related to the validation.
        /// </summary>
        public IEnumerable<string> Errors { get; }

        /// <summary>
        /// Returns a new instance of a successful result.
        /// </summary>
        /// <returns>A new instance of a <see cref="ObjectVerificationResult"/>.</returns>
        public static ObjectVerificationResult Successful()
        {
            return new ObjectVerificationResult(false, Enumerable.Empty<string>());
        }

        /// <summary>
        /// Returns a new instance of a failed result.
        /// </summary>
        /// <param name="errors">A list of any errors that occurred.</param>
        /// <returns>A new instance of a <see cref="ObjectVerificationResult"/>.</returns>
        public static ObjectVerificationResult Failure(IEnumerable<string> errors)
        {
            return new ObjectVerificationResult(true, errors);
        }
    }
}
