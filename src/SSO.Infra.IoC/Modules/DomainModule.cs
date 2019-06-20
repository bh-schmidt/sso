using Autofac;
using SSO.Domain.Interfaces.Users;
using SSO.Domain.Services.Users;

namespace SSO.Infra.IoC.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InsertUserService>().As<IInsertUserService>();
        }
    }
}
