using FluentValidation;
using System.Data;

namespace SSO.Domain.Users.InsertUsers
{
    public class InsertUserContract : AbstractValidator<User>, IInsertUserContract
    {
        public InsertUserContract()
        {
            RuleFor(x => x.Id)
                .Empty();

            RuleFor(x => x.Email)
                .ValidateEmail();

            RuleFor(x => x.Username)
                .ValidateUsername();

            RuleFor(x => x.Password)
                .ValidatePassword();
        }
    }
}
