using Api.Domain.Users.InsertUsers;
using Autofac;

namespace Api.Infra.CrossCutting.IoC.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InsertUserService>().As<IInsertUserService>();
        }
    }
}
