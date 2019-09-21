using FluentValidation;

namespace SSO.Domain.Users.InsertUsers
{
    public class InsertUserContract : AbstractValidator<User>
    {
        public InsertUserContract()
        {
            RuleFor(x => x.Id)
                .Empty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(x => x.Password)
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
