using FluentValidation;

namespace SSO.Domain
{
    public interface IBaseModelRules
    {
        IRuleBuilderOptions<TModel, string> ValidateIdToInsert<TModel>(IRuleBuilder<TModel, string> rule) where TModel : BaseModel;
    }
}
