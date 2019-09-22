using Autofac;

namespace SSO.Infra.CrossCutting.IoC.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private static IContainer _container;

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
