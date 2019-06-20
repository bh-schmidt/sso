using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SSO.Infra.IoC.Modules;
using System;

namespace SSO.Infra.IoC
{
    public static class IoCConfiguration
    {
        public static IServiceProvider ConfigureContainer(IServiceCollection serviceCollection)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Populate(serviceCollection);

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new DataModule());

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
