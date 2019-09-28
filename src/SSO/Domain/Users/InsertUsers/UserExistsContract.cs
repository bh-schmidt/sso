﻿using FluentValidation;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
{
    public class UserExistsContract : AbstractValidator<User>, IUserExistsContract
    {
        public UserExistsContract(IServiceLocator serviceLocator)
        {
            if (serviceLocator.IsNull())
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }

            var userRepository = serviceLocator.Resolve<IUserRepository>();

            RuleFor(x => x.Email)
                .NotEmpty()
                .MustAsync(async (email, _) => !await userRepository.EmailExists(email))
                .WithMessage("This email already exists.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .MustAsync(async (username, _) => !await userRepository.UsernameExists(username))
                .WithMessage("This username already exists.");
        }
    }
}
