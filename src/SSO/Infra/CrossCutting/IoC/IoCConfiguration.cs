using Autofac;
using Autofac.Extensions.DependencyInjection;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.Modules;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System;

namespace SSO.Infra.CrossCutting.IoC
{
    public static class IoCConfiguration
    {
        public static IServiceProvider ConfigureServiceLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new DataModule());
            AddServiceLocatorTo(builder);

            var container = builder.Build();

            ServiceLocator.ServiceLocator.SetContainer(container);

            return new AutofacServiceProvider(container);
        }

        public static void AddServiceLocatorTo(ContainerBuilder builder)
        {
            if (builder.IsNull())
            {
                throw new ArgumentException(nameof(builder));
            }

            builder.RegisterType<ServiceLocator.ServiceLocator>().As<IServiceLocator>();
        }
    }
}
