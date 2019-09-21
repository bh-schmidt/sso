using FluentValidation;
using FluentValidation.Results;

namespace Api.Domain
{
    public class BaseModel
    {
        public string Id { get; set; }
        public bool Valid => ValidationResult.IsValid;
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public BaseModel()
        {
            ValidationResult = new ValidationResult();
        }

        protected virtual void Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult =  validator.Validate(model);
        }
    }
}
