namespace SSO.Infra.CrossCutting.IoC.ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>();
    }
}
