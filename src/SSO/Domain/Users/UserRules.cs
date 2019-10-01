using FluentValidation;

namespace SSO.Domain.Users
{
    public static class UserRules
    {
        public static IRuleBuilderOptions<T, string> ValidateEmail<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .EmailAddress();
        }

        public static IRuleBuilderOptions<T, string> ValidateUsername<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);
        }

        public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> rule)
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
