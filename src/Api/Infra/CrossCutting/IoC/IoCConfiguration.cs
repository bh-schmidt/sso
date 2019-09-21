using Api.Infra.CrossCutting.IoC.Modules;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Infra.CrossCutting.IoC
{
    public static class IoCConfiguration
    {
        public static IServiceProvider ConfigureContainer(IServiceCollection serviceCollection)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Populate(serviceCollection);

            builder.RegisterType<ServiceLocator.ServiceLocator>().As<IServiceLocator>();

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new DataModule());

            var container = builder.Build();

            ServiceLocator.ServiceLocator.SetContainer(container);

            return new AutofacServiceProvider(container);
        }
    }
}
