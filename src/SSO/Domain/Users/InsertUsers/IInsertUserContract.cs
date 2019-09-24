using FluentValidation;

namespace SSO.Domain.Users.InsertUsers
{
    public interface IInsertUserContract : IValidator<User>
    {
    }
}
