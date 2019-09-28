
using Autofac;
using SSO.Infra.CrossCutting.Cryptography;

namespace SSO.Infra.CrossCutting.IoC.Modules
{
    public class InfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordCryptography>().As<IPasswordCryptography>();
        }
    }
}
