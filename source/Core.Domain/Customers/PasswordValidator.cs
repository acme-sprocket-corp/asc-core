using FluentValidation;

namespace Core.Domain.Customers
{
    /// <summary>
    /// Validator object for a string based password.
    /// </summary>
    public class PasswordValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordValidator"/> class.
        /// </summary>
        public PasswordValidator()
        {
            RuleFor(password => password).MinimumLength(PasswordRequirements.MinimumPasswordLength);
            RuleFor(password => password).Matches(PasswordRequirements.PasswordRegex);
        }
    }
}
