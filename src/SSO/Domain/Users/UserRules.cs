using FluentValidation;

namespace SSO.Domain.Users
{
    public class UserRules : IUserRules
    {
        public IRuleBuilderOptions<User, string> ValidateEmail(IRuleBuilder<User, string> rule)
        {
            return rule
                .NotEmpty()
                .EmailAddress();
        }

        public IRuleBuilderOptions<T, string> ValidateUsername<T>(IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }

        public IRuleBuilderOptions<T, string> ValidatePassword<T>(IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(30)
                .Matches(@"[a-z]")
                .WithMessage("The password needs at least 1 lower case letter.")
                .Matches(@"[A-Z]")
                .WithMessage("The password needs at least 1 upper case letter.")
                .Matches(@"[\d]")
                .WithMessage("The password needs at least 1 numeric digit.")
                .Matches(@"[\W]")
                .WithMessage("The password needs at least 1 special character.");
        }
    }
}
