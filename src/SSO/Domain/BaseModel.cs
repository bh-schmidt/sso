using FluentValidation;
using FluentValidation.Results;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System;
using System.Threading.Tasks;

namespace SSO.Domain
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        public bool Valid => ValidationResult.IsValid;
        public ValidationResult ValidationResult { get; private set; }

        public BaseModel()
        {
            ValidationResult = new ValidationResult();
        }

        public virtual void Validate<TValidator>(IServiceLocator serviceLocator) where TValidator : IValidator
        {
            if (serviceLocator.IsNull())
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }

            var validator = serviceLocator.Resolve<TValidator>();
            ValidationResult = validator.Validate(this);
        }

        public virtual async Task ValidateAsync<TValidator>(IServiceLocator serviceLocator) where TValidator : IValidator
        {
            if (serviceLocator.IsNull())
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }

            var validator = serviceLocator.Resolve<TValidator>();
            ValidationResult = await validator.ValidateAsync(this);
        }
    }
}
