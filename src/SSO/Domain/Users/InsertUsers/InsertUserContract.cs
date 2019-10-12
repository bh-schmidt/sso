using FluentValidation;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System;
using System.Data;

namespace SSO.Domain.Users.InsertUsers
{
    public class InsertUserContract : AbstractValidator<User>, IInsertUserContract
    {
        public InsertUserContract(IServiceLocator serviceLocator)
        {
            var baseModelRules = serviceLocator.Resolve<IBaseModelRules>();
            baseModelRules.ThrowIfNull(nameof(baseModelRules));

            var userRules = serviceLocator.Resolve<IUserRules>();
            userRules.ThrowIfNull(nameof(userRules));

            baseModelRules.ValidateIdToInsert(RuleFor(u => u.Id));
            userRules.ValidateEmail(RuleFor(u => u.Email));
            userRules.ValidateUsername(RuleFor(u => u.Username));
            userRules.ValidatePassword(RuleFor(u => u.Password));
        }
    }
}
