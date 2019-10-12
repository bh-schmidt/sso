using FluentValidation;

namespace SSO.Domain.Users
{
    public interface IUserRules
    {
        IRuleBuilderOptions<User, string> ValidateEmail(IRuleBuilder<User, string> rule);
        IRuleBuilderOptions<T, string> ValidateUsername<T>(IRuleBuilder<T, string> rule);
        IRuleBuilderOptions<T, string> ValidatePassword<T>(IRuleBuilder<T, string> rule);
    }
}
