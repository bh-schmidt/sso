using FluentValidation;

namespace SSO.Domain
{
    public class BaseModelRules : IBaseModelRules
    {
        public IRuleBuilderOptions<TModel, string> ValidateIdToInsert<TModel>(IRuleBuilder<TModel, string> rule) where TModel : BaseModel
        {
            return rule
                .Null();
        }
    }
}
