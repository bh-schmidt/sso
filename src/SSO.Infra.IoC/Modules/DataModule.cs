using Autofac;
using SSO.Infra.Data.Interfaces.Users;
using SSO.Infra.Data.Repositories.Users;

namespace SSO.Infra.IoC.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
