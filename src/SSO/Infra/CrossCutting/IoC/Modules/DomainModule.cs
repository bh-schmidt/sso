using Autofac;
using SSO.Domain.Users.InsertUsers;

namespace SSO.Infra.CrossCutting.IoC.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InsertUserService>().As<IInsertUserService>();
            builder.RegisterType<UserExistsContract>().As<IUserExistsContract>();
            builder.RegisterType<InsertUserContract>().As<IInsertUserContract>();
        }
    }
}
