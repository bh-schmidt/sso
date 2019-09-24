using FluentValidation;

namespace SSO.Domain.Users.InsertUsers
{
    public interface IUserExistsContract : IValidator<User>
    {
    }
}
